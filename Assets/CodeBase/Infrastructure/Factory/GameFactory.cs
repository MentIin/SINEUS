using CodeBase.Infrastructure.Services.Audio;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.Pause;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.Random;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Infrastructure.States;
using CodeBase.Logic.CameraLogic;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory
    {
        private readonly StaticDataService _staticData;
        private readonly IRandomService _randomService;
        private readonly GameStateMachine _gameStateMachine;
        private readonly PersistentProgressService _progressService;
        private readonly IInputService _inputService;
        private readonly AudioService _audioService;
        private readonly CameraController _cameraController;
        private readonly PauseService _pauseService;

        public GameFactory(StaticDataService staticData, IRandomService randomService,
            GameStateMachine gameStateMachine, PersistentProgressService progressService,
            IInputService inputService, AudioService audioService, 
            CameraController cameraController, PauseService pauseService)
        {
            _staticData = staticData;
            _randomService = randomService;
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _inputService = inputService;
            _audioService = audioService;
            _cameraController = cameraController;
            _pauseService = pauseService;
        }
    }
}