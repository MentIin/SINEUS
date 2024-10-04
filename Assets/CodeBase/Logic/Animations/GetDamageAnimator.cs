using System;
using UnityEngine;

namespace CodeBase.Logic.Animations
{
    public class GetDamageAnimator : MonoBehaviour
    {
        public Health health;
        public SpriteRenderer renderer;
        public SpriteRenderer[] additionals = new SpriteRenderer[0];

        private GetDamageSimpleAnimation _animation;
        private void Awake()
        {
            health.DamageTaken += HealthOnDamageTaken;
            _animation = new GetDamageSimpleAnimation(renderer, additionals);
        }

        private void HealthOnDamageTaken(int obj)
        {
            _animation.Activate();
        }

        private void Update()
        {
            _animation.Update();
        }
    }
}