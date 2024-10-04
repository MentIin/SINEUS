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
        
        [Header("Ignore if not main menu")]
        [SerializeField]private bool _save = false;

        public void Construct(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _button.onClick.AddListener(ChangeState);
        }


        private void ChangeState()
        {
            if (_state == State.MainMenu) _stateMachine.Enter<MainMenuState>();
        }
    }

    internal enum State
    {
        MainMenuWithCleaning=1, NewGame=2,MainMenu=3,
    }
}