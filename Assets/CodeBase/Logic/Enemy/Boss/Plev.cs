using System.Collections;
using UnityEngine;

namespace CodeBase.Logic.Enemy.Boss
{
    public class Plev : MonoBehaviour
    {
        public Animator Animator;
        public GameObject Plevok;
        public void Construct(float lifetime)
        {
            Destroy(this.gameObject, lifetime+1f);
            StartCoroutine(Cor(lifetime));
        }

        private IEnumerator Cor(float time)
        {
            yield return new WaitForSeconds(time);
            GameObject go = Instantiate(Plevok);
            go.transform.parent = Camera.main.transform;
            go.transform.position = Animator.transform.position;
            Animator.SetTrigger("plev");
        }
    }
}