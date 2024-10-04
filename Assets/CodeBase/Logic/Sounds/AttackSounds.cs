using System;
using CodeBase.Logic.Attacks;
using UnityEngine;

namespace CodeBase.Logic.Sounds
{
    public class AttackSounds : MonoBehaviour
    {
        public Attack attack;
        public PlaySound PlaySound;

        private void Awake()
        {
            attack.AttackStarted += AttackStarted;
        }

        private void AttackStarted()
        {
            PlaySound.PlayOneShot();
        }
    }
}