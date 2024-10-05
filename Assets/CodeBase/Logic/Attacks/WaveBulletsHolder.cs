using CodeBase.Logic.Attacks;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WaveBulletsHolder : MonoBehaviour
{
    [HideInInspector] public int damage;
    [HideInInspector] public Attack parentAttack;
    [SerializeField] private List<BulletSimple> bullets;
    private void Start()
    {
        foreach (BulletSimple bullet in bullets)
        {
            bullet.damage=damage;
            bullet.parentAttack=parentAttack;
        }
    }
}
