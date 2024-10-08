using CodeBase.Logic;
using CodeBase.Logic.Attacks;
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
        collider.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Health health;
        if (col.TryGetComponent(out health))
        {
            if (health.Team != this.Team)
            {
                health.TakeDamage(damage);
                Debug.Log("sdoh");
            }
        }
    }
    private void DealDamage()
    {

        
        foreach (var col in Physics2D.OverlapBoxAll(collider.bounds.center, collider.size, 0))
        {
            
        }
    }

    public override bool StartAttack()
    {
        DealDamage();
        return true;
    }
}
