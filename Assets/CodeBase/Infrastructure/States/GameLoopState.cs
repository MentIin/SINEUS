using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.Audio;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    class GameLoopState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly GameFactory _gameFactory;
        private readonly AudioService _audioService;

        public GameLoopState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, ICoroutineRunner coroutineRunner,
            GameFactory gameFactory, AudioService audioService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _coroutineRunner = coroutineRunner;
            _gameFactory = gameFactory;
            _audioService = audioService;
        }

        public void Exit()
        {
            
        }

        public void Enter()
        {
            Debug.Log("Enter GameLoop");
        }
    }
}