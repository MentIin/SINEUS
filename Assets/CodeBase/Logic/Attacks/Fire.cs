using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Logic.Attacks
{
    public class Fire : MonoBehaviour
    {
        public Health Target;
        public int Damage = 1;
        public float Lifetime = 3;


        private void Start()
        {
            StartCoroutine(DealDamage());
        }

        private IEnumerator DealDamage()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                Target.TakeDamage(Damage);
                Lifetime -= 1f;
                if (Lifetime <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
            
        }
        public static void DealFire(Health health, GameObject FirePrefab)
        {
            if (FirePrefab != null)
            {
                Fire fire = health.GetComponentInChildren<Fire>();
                if (fire)
                {
                    fire.Lifetime = 3f;
                }
                else
                {
                    GameObject go = Instantiate(FirePrefab, health.transform);
                    go.GetComponent<Fire>().Lifetime = 3f;
                    go.GetComponent<Fire>().Damage = 2;
                    go.GetComponent<Fire>().Target = health;
                }
            }
        }
    }
}