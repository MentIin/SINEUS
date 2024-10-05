using System.Collections;
using CodeBase.Logic.Attacks.Projectiles;
using UnityEngine;

namespace CodeBase.Logic.Attacks
{
    public class AttackProjectile : Attack
    {
        
        public int damage = 1;
        public float reload = 1;
        public float timeBeforeHit = 0.1f;


        public Bullet bulletPrefab;
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
            InvokeStarted();

            yield return new WaitForSeconds(timeBeforeHit);

            Bullet bullet = Instantiate(bulletPrefab, transform);
            bullet.damage = damage;
            bullet.parentAttack = this;
            yield return new WaitForSeconds(reload);
            _canAttack = true;
        }
    }
}