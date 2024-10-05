using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Audio;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.Pause;
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
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _allServices;
        private readonly LoadingCurtain _loadingCurtain;
        private AudioSource _audioSource;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly CameraController _cameraController;
        
        
        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices allServices,
            LoadingCurtain loadingCurtain, AudioSource audioSource, ICoroutineRunner coroutineRunner,
            CameraController cameraController, AudioMixerGroup musicMixerGroup, AudioMixerGroup soundsMixerGroup)
        {
            _audioSource = audioSource;
            _coroutineRunner = coroutineRunner;
            _cameraController = cameraController;
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _allServices = allServices;
            _loadingCurtain = loadingCurtain;
            RegisterServices(soundsMixerGroup, musicMixerGroup);
        }

        public void Exit()
        {
            
        }

        public void Enter()
        {
            _gameStateMachine.Enter<LoadProgressState>();
        }

        private void RegisterServices(AudioMixerGroup soundsMixerGroup, AudioMixerGroup musicMixerGroup)
        {
            _allServices.RegisterSingle<IRandomService>(new RandomService(662));
            
            _allServices.RegisterSingle<StaticDataService>(new StaticDataService());
            _allServices.RegisterSingle<PersistentProgressService>(new PersistentProgressService());

            _allServices.RegisterSingle<AudioService>(new AudioService(_audioSource,
                 _coroutineRunner,
                _allServices.Single<PersistentProgressService>(), soundsMixerGroup,
                musicMixerGroup));
            _allServices.RegisterSingle<PauseService>(new PauseService(_allServices.Single<AudioService>()));


            _allServices.RegisterSingle<ISaveLoadService>(
                            new SaveLoadService(_allServices.Single<PersistentProgressService>()));
            

            _allServices.RegisterSingle<IInputService>(new StandaloneInputService(_coroutineRunner));
            

        _allServices.RegisterSingle<GameStateMachine>(_gameStateMachine);

            
            RegisterUIFactory();

            RegisterFactory();

            _allServices.Single<IInputService>().Initialize();
            
            
            
            
        }

        private void RegisterUIFactory()
        {
            _allServices.RegisterSingle<UIFactory>(new UIFactory(
                _allServices.Single<StaticDataService>(), 
                _allServices.Single<PersistentProgressService>(),
                _gameStateMachine, _allServices.Single<AudioService>(), _allServices.Single<PauseService>(),
                _allServices.Single<ISaveLoadService>()));
        }

        private void RegisterFactory()
        {
            _allServices.RegisterSingle<GameFactory>(new GameFactory(
                _allServices.Single<StaticDataService>(),
                _allServices.Single<IRandomService>(),
                _gameStateMachine, _allServices.Single<PersistentProgressService>(),
                _allServices.Single<IInputService>(), _allServices.Single<AudioService>(),
                _cameraController,
                _allServices.Single<PauseService>())
            );
        }
    }
}