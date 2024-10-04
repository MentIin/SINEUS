using System;
using CodeBase.Infrastructure.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Logic.Attacks;
using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class PlayerController : MonoBehaviour
    {
        public Attack CurrentAttack;
        public CharacterController2D controller;
        private IInputService _input;

        public Action AttackStarted;

        private void Start()
        {
            _input = AllServices.Container.Single<IInputService>();
        }

        private void Update()
        {
            if (_input.Attack())
            {
                if (CurrentAttack.StartAttack())
                {
                    AttackStarted?.Invoke();
                }
                
            }
            
            controller.Walk(_input.GetAxis().x);
            if (_input.JumpStart())
            {
                controller.Jump();
            }else if (_input.JumpEnd())
            {
                controller.EndJump();
            }
        }

        public void SetAttack(Attack attack)
        {
            CurrentAttack = attack;
            CurrentAttack.Team = Team.Player;
        }
    }
}