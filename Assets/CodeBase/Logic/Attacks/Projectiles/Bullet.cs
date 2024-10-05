using UnityEngine;

namespace CodeBase.Logic.Attacks.Projectiles
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private LayerMask LayerMask;
        [HideInInspector] public int damage;
        [HideInInspector] public Attack parentAttack;
    
        [SerializeField] private float speed=4;
        [SerializeField] private int lifeTime = 10;
        private void Start()
        {
            Invoke("Lopnul", lifeTime);
        }
        private void Update()
        {
            Move();
        }
        private void DealDamage(Health health) {
            health.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        private void Move()
        {
            RaycastHit2D[] raycastHit2Ds = Physics2D.RaycastAll(transform.position, transform.right, speed * Time.deltaTime);


            Health health;
            foreach (var hit2D in raycastHit2Ds)
            {
                if (hit2D.collider.TryGetComponent(out health))
                {
                    if (health.Team != parentAttack.Team)
                    {
                        DealDamage(health);
                        transform.position = hit2D.point;
                        return;
                    }
                }
            }

            transform.position = transform.position + transform.right * speed * Time.deltaTime;
        }
        private void Lopnul()
        {
            Destroy(gameObject);
        }
    }
}
