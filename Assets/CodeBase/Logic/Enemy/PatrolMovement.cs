using System;
using CodeBase.Logic.Enemy.Chekers;
using UnityEngine;

namespace CodeBase.Logic.Enemy
{
    public class PatrolMovement : MonoBehaviour
    {
        public CharacterController2D _controller;
        public CheckPlatformEnd _checker;

        private int direction = 1;


        private void Update()
        {
            _controller.Walk(direction);
            if (_checker.Check())
            {
                direction *= -1;
            }
        }
    }
}