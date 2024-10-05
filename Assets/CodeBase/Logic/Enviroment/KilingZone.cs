using CodeBase.Logic;
using CodeBase.Logic.Attacks;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class KilingZone : Attack
{
    [SerializeField] private int damage = 9999;
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType=RigidbodyType2D.Static;
        collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartAttack();
    }
    private void DealDamage()
    {

        Health health;
        foreach (var col in Physics2D.OverlapBoxAll(collider.bounds.center, collider.size, 0))
        {
            if (col.TryGetComponent(out health))
            {
                if (health.Team != this.Team)
                {
                    health.TakeDamage(damage);
                    Debug.Log("sdoh");
                }
            }
        }
    }

    public override bool StartAttack()
    {
        DealDamage();
        return true;
    }
}
