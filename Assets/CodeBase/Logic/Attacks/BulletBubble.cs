using CodeBase.Logic;
using CodeBase.Logic.Attacks;
using UnityEngine;

public class BulletBubble : MonoBehaviour
{
    [HideInInspector] public int damage;
    [HideInInspector] public Attack parentAttack;

    [SerializeField] private CircleCollider2D _collider2D;

    [SerializeField] private float speed=4;
    [SerializeField] private float frequency = 15;
    [SerializeField] private float magnitude = 0.3f;
    private Vector3 pos;

    [SerializeField] private int lifeTime = 10;
    private void Start()
    {
        pos= transform.localPosition;
        _collider2D = GetComponent<CircleCollider2D>();
        Invoke("Lopnul", lifeTime);

    }
    private void Update()
    {
        SinusMoving();
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
                    Lopnul();
                }
            }
        }
    }
    private void SinusMoving()
    {
        pos += transform.right * Time.deltaTime * speed;
        transform.localPosition = pos+transform.up*Mathf.Sin((Time.time+Time.deltaTime)*frequency)*magnitude;
    }
    private void Lopnul()
    {
        Destroy(gameObject);
    }
}
