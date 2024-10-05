using CodeBase.Logic.Attacks;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AttackCircleWave : Attack
{
    public int damage = 1;
    public float reload = 1;
    public float timeBeforeHit = 0.1f;

    private bool _canAttack = true;

    public WaveBulletsHolder bulletPrefab;
    [SerializeField] private Transform shotPos;
    public override bool StartAttack()
    {
        if (!_canAttack) return false;
        StartCoroutine(Coroutine());
        return true;
    }

    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(timeBeforeHit);
        _canAttack = false;

        WaveBulletsHolder bullet = Instantiate(bulletPrefab, shotPos.position, Quaternion.identity);
        bullet.damage = damage;
        bullet.parentAttack = this;;
            
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
