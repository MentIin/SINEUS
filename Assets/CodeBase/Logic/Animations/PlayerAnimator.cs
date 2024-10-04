using CodeBase.Logic.Attacks;
using CodeBase.Logic.Player;
using UnityEngine;

namespace CodeBase.Logic.Animations
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Attack _controller;
        private Animator _anim;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _controller.AttackStarted += AttackStart;
        }

        private void AttackStart()
        {
            _anim.SetTrigger("attack");
        }
    }
}