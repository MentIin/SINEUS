using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Audio;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.Random;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Logic.CameraLogic;
using CodeBase.UI;
using CodeBase.UI.Services.UIFactory;
using UnityEngine;
using UnityEngine.Audio;

namespace CodeBase.Infrastructure.States
{
    public class GameStateMachine : BaseStateMachine
    {
        private readonly SceneLoader _sceneLoader;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly AllServices _allServices;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly AudioSource _audioSource;
        private readonly CameraController _cameraController;
        private readonly AudioMixerGroup _musicMixerGroup;
        private readonly AudioMixerGroup _soundsMixerGroup;

        public GameStateMachine(SceneLoader sceneLoader, ICoroutineRunner coroutineRunner, AllServices allServices,
            LoadingCurtain loadingCurtain, AudioSource audioSource, CameraController cameraController,
            AudioMixerGroup musicMixerGroup, AudioMixerGroup soundsMixerGroup)
        {
            _sceneLoader = sceneLoader;
            _coroutineRunner = coroutineRunner;
            _allServices = allServices;
            _loadingCurtain = loadingCurtain;
            _audioSource = audioSource;
            _cameraController = cameraController;
            _musicMixerGroup = musicMixerGroup;
            _soundsMixerGroup = soundsMixerGroup;
            _states = new Dictionary<Type, IExitableState>();
            
            BootstrapState bootstrapState = new BootstrapState(this, sceneLoader, allServices, loadingCurtain, audioSource,
                coroutineRunner, cameraController, musicMixerGroup, soundsMixerGroup);

                _states = new Dictionary<Type, IExitableState>()
                {
                    [typeof(BootstrapState)] = bootstrapState
                };
            InitializeStates(bootstrapState);
        }
             

        public void InitializeStates(BootstrapState bootstrapState)
        {
            _states[typeof(BootstrapState)] = bootstrapState;
            _states[typeof(GameLoopState)] = new GameLoopState(this, _sceneLoader, _coroutineRunner,
                _allServices.Single<GameFactory>(),
                _allServices.Single<AudioService>());
            
            _states[typeof(LoadProgressState)] = new LoadProgressState(this,
                _allServices.Single<PersistentProgressService>(),
                _allServices.Single<ISaveLoadService>(), _allServices.Single<StaticDataService>());
            _states[typeof(MainMenuState)] = new MainMenuState(this, _allServices.Single<PersistentProgressService>(),
                _allServices.Single<UIFactory>(), _loadingCurtain, _sceneLoader);
            
            _states[typeof(LoadLevelState)] = new LoadLevelState(this,  _sceneLoader, _allServices.Single<GameFactory>(),
                _allServices.Single<StaticDataService>(), _allServices.Single<IRandomService>(), _allServices.Single<PersistentProgressService>(),
                _allServices.Single<IInputService>(), _loadingCurtain, _cameraController);
        }
    }
}