using Assets.CodeBase.Logic.CameraLogic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.Random;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Logic;
using CodeBase.Logic.CameraLogic;
using CodeBase.UI;
using CodeBase.UI.Services.UIFactory;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<int>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly GameFactory _gameFactory;
        private readonly StaticDataService _staticDataService;
        private readonly IRandomService _randomService;
        private readonly PersistentProgressService _progressService;
        private readonly IInputService _inputService;
        private readonly LoadingCurtain _loadingCurtain;
        private CameraController _cameraController;
        private readonly UIFactory _uiFactory;

        private const string GameSceneName = "GameScene";

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, GameFactory gameFactory,
            StaticDataService staticDataService, IRandomService randomService, PersistentProgressService progressService,
            IInputService inputService, LoadingCurtain loadingCurtain,
            CameraController cameraController, UIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _staticDataService = staticDataService;
            _randomService = randomService;
            _progressService = progressService;
            _inputService = inputService;
            _loadingCurtain = loadingCurtain;
            _cameraController = cameraController;
            _uiFactory = uiFactory;
        }

        public void Enter(int levelId)
        {
            _progressService.Progress.GameData.LastLevel = levelId;
            _cameraController.SetScaleToDefault();
            _cameraController.RemoveShade();
            
            _sceneLoader.Load(_staticDataService.AllLevels.Levels[levelId].Scene, OnLoaded);
        }

        public void Exit()
        {
        }

        private async void OnLoaded()
        {
            GameObject gameObject = _gameFactory.CreatePlayer(Vector2.zero);
            CameraFollow(gameObject.transform);

            gameObject.GetComponent<Death>().Happen += OnHappen;
            
            _uiFactory.CreateHUD();
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void OnHappen()
        {
            _gameStateMachine.Enter<LoadLevelState, int>(_progressService.Progress.GameData.LastLevel);
        }

        private void CameraFollow(Transform target)
        {
            CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();
            cameraFollow.Follow(target);
            cameraFollow.TeleportToTarget();
        }
    }
}