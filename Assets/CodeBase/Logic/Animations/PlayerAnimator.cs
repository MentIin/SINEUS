using System;
using CodeBase.Logic.Attacks;
using CodeBase.Logic.Player;
using CodeBase.Logic.Sounds;
using UnityEngine;

namespace CodeBase.Logic.Animations
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Attack _controller;
        [SerializeField] private CharacterController2D _characterController;
        public PlaySound WalkSound;
        
        private Animator _anim;

        private void Start()
        {
            if (WalkSound != null) WalkSound.StartPlaying();
            _anim = GetComponent<Animator>();
            _controller.AttackStarted += AttackStart;
        }

        private void Update()
        {
            if (WalkSound == null) return;
            if (_characterController.speed.x > 0.1)
            {
                WalkSound.Volume = 1f;
            }
            else
            {
                WalkSound.Volume = 0f;
            }
        }

        private void AttackStart()
        {
            _anim.SetTrigger("attack");
        }
    }
}