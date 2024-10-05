using UnityEngine;
using System.Collections;
namespace CodeBase.Logic.Attacks
{
    class AttackBoomerang : Attack
    {
        public int damage = 1;
        //public float attackDuration = 1.5f;
        public float reload=1;
        public float timeBeforeHit = 0.1f;

        //public CircleCollider2D _collider2D;
        private bool _canAttack=true;

        public BoomerangBullet bulletPrefab;
        [SerializeField] private Transform shotPos;
        [SerializeField] private SpriteRenderer handRenderer;
        private Vector3 mouseClickPos;
        public override bool StartAttack()
        {
            if (!_canAttack) return false;
            StartCoroutine(Coroutine());
            return true;
        }

        private IEnumerator Coroutine()
        {
            mouseClickPos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseClickPos = new Vector3(mouseClickPos.x, mouseClickPos.y, 0);
            _canAttack = false;
            yield return new WaitForSeconds(timeBeforeHit);

            Vector2 myPos = shotPos.position;
            float angle = Mathf.Atan2(mouseClickPos.y - myPos.y, mouseClickPos.x - myPos.x) * Mathf.Rad2Deg;
            Quaternion bulletRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);

            BoomerangBullet bullet = Instantiate(bulletPrefab, shotPos.position, bulletRotation);
            bullet.damage = damage;
            bullet.parentAttack= this;
            bullet.targetPos = mouseClickPos;
            bullet.handRenderer = handRenderer;

            
        }
        private IEnumerator AttackReload()
        {
            yield return new WaitForSeconds(reload);
            _canAttack = true;
        }
        public void StartReload()
        {
            StartCoroutine(AttackReload());
        }
        
    }
}