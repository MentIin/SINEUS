using CodeBase.Logic;
using CodeBase.Logic.Attacks;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class BulletSimple : MonoBehaviour
{
    [HideInInspector] public int damage;
    [HideInInspector] public Attack parentAttack;

    [SerializeField] private CircleCollider2D _collider2D;

    [SerializeField] private float speed;
    [SerializeField] private float lifeTime = 10;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;

        _collider2D = GetComponent<CircleCollider2D>();

        Invoke("Smert", lifeTime);
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        rb.linearVelocity=transform.right*speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DealDamage();
    }
    private void DealDamage()
    {

        Health health;
        foreach (var col in Physics2D.OverlapCircleAll(_collider2D.bounds.center,
            _collider2D.radius))
        {
            if (col.TryGetComponent(out health))
            {
                if (health.Team != parentAttack.Team)
                {
                    health.TakeDamage(damage);
                    Smert();
                }
            }
        }
    }
    private void Smert()
    {
        Destroy(gameObject);
    }
}
