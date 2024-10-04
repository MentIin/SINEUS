using System.Collections;
using UnityEngine;

namespace CodeBase.Logic.Attacks
{
    class AttackMelee : Attack
    {
        public float reload=0.5f;
        public float attackDuration=0.2f;
        public float timeBeforeHit = 0.1f;
        
        public CircleCollider2D _collider2D;
        private bool _canAttack = true;
        public override bool StartAttack()
        {
            if (!_canAttack) return false;
            StartCoroutine(Coroutine());
            return true;
        }

        private IEnumerator Coroutine()
        {
            _canAttack = false;
            yield return new WaitForSeconds(timeBeforeHit);
            DealDamage();
            yield return new WaitForSeconds(attackDuration - timeBeforeHit + reload);
            _canAttack = true;
        }
        private void DealDamage()
        {
            Health health;
            foreach (var col in Physics2D.OverlapCircleAll(_collider2D.bounds.center,
                _collider2D.radius))
            {
                if (col.TryGetComponent(out health))
                {
                    if (health.Team != Team)
                    {
                        health.TakeDamage(1);
                    }
                }
            }
        }
    }
}