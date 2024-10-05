using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements.Buttons
{
    public class ChangeStateButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private State _state = State.MainMenu;
        private GameStateMachine _stateMachine;
        

        public void Construct(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _button.onClick.AddListener(ChangeState);
        }


        private void ChangeState()
        {
            PersistentProgressService progressService = AllServices.Container.Single<PersistentProgressService>();
            if (_state == State.MainMenu) _stateMachine.Enter<MainMenuState>();
            else if (_state == State.NewGame) _stateMachine.Enter<LoadLevelState, int>(0);
        }
    }

    internal enum State
    {
        MainMenuWithCleaning=1, NewGame=2,MainMenu=3,
    }
}