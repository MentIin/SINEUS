using System;
using CodeBase.Logic.Attacks;
using CodeBase.Logic.Enemy.AI;
using CodeBase.Logic.Player;
using CodeBase.Logic.Sounds;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Logic.Animations
{
    [RequireComponent(typeof(Animator))]
    public class RiderAnimator : MonoBehaviour
    {
        [SerializeField] private Attack _attack;
        [SerializeField] private CharacterController2D _characterController;
        public RiderAI AI;
        public PlaySound WalkSound;
        
        private Animator _anim;

        private void Start()
        {
            if (WalkSound != null) WalkSound.StartPlaying();
            _anim = GetComponent<Animator>();
            _attack.AttackStarted += AttackStart;
            
            
        }

        private void Update()
        {
            _anim.SetBool("stunned", AI.Stunned);
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