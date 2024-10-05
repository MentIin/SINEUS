using CodeBase.Logic.Attacks;
using UnityEngine;using System.Collections;
public class AttackBubble : Attack
{
    public int damage = 1;
    public float reload = 1;
    public float timeBeforeHit = 0.1f;

    private bool _canAttack = true;

    public BulletBubble bulletPrefab;
    [SerializeField] private int bubblesCount = 4;
    [SerializeField] private Transform shotPos;
    //[SerializeField] private SpriteRenderer handRenderer;
    private Vector3 mouseClickPos;
    public override bool StartAttack()
    {
        if (!_canAttack) return false;
        StartCoroutine(Coroutine());
        return true;
    }

    private IEnumerator Coroutine()
    {
        mouseClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseClickPos = new Vector3(mouseClickPos.x, mouseClickPos.y, 0);
        _canAttack = false;

        InvokeStarted();
        
        for (int i = 0; i < bubblesCount; i++)
        {
            Vector2 myPos = shotPos.position;
            float angle = Mathf.Atan2(mouseClickPos.y - myPos.y, mouseClickPos.x - myPos.x) * Mathf.Rad2Deg;
            Quaternion bulletRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);

            BulletBubble bullet = Instantiate(bulletPrefab, shotPos.position, bulletRotation);
            bullet.damage = damage;
            bullet.parentAttack = this;
            //bullet.targetPos = mouseClickPos;
            yield return new WaitForSeconds(timeBeforeHit);
        }
        StartReload();

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