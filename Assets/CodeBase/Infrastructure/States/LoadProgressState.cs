using CodeBase.Infrastructure.Data.PlayerData;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.Services.StaticData;

namespace CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private GameStateMachine _stateMachine;
        private PersistentProgressService _progressService;
        private ISaveLoadService _saveLoadService;
        private readonly StaticDataService _staticDataService;

        public LoadProgressState(GameStateMachine stateMachine,
            PersistentProgressService progressService,
            ISaveLoadService saveLoadService, StaticDataService staticDataService)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            _staticDataService.Load();
            if (_saveLoadService.LoadProgress() == null) _progressService.Progress = GetNewProgress();
            else _progressService.Progress = _saveLoadService.LoadProgress();


            _stateMachine.Enter<MainMenuState>();
        }

        public void Exit()
        {
            
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress =  _saveLoadService.LoadProgress() ?? GetNewProgress();
        }

        private PlayerProgress GetNewProgress()
        {
            PlayerProgress playerProgress = new PlayerProgress();
            
            playerProgress.GameData.playerPocket.Add(GameData.MagicStonesTypes.Gravity);
            playerProgress.GameData.playerPocket.Add(GameData.MagicStonesTypes.BoomerangAttack);
            playerProgress.GameData.playerPocket.Add(GameData.MagicStonesTypes.BubbleAttack);
            playerProgress.GameData.playerPocket.Add(GameData.MagicStonesTypes.Jump);
            playerProgress.GameData.playerPocket.Add(GameData.MagicStonesTypes.ZoneSplash);

            for (int i = 0; i < 5; i++)
            {
                playerProgress.GameData.playerSlots[i] = 
                    (GameData.MagicStonesTypes.Null);

            }


            //playerProgress.GameData.playerSlots[2] = (GameData.MagicStonesTypes.BoomerangAttack);
            // some start values
            
            return playerProgress;
        }
    }
}