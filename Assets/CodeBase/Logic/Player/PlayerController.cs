using System;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class PlayerController : MonoBehaviour
    {
        public CharacterController2D controller;
        private IInputService _input;

        private void Start()
        {
            _input = AllServices.Container.Single<IInputService>();
        }

        private void Update()
        {
            controller.Walk(_input.GetAxis().x);
        }
    }
}