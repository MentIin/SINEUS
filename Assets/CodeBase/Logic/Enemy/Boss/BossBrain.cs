using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


namespace CodeBase.Logic.Enemy.Boss
{
    public class BossBrain : MonoBehaviour
    {
        public SongData Song;
        public GameObject PlevPrefab;

        private void Start()
        {
            StartCoroutine(SpawnPlevs());
        }

        // plevs
        private IEnumerator SpawnPlevs()
        {
            int id = 0;
            float sum = 0f;
            while (true)
            {
                float toWait = Song.Timings[id] - sum;
                sum += toWait;
                yield return new WaitForSeconds(toWait);

                Spawn();

                id++;
            }
        }

        private void Spawn()
        {
            GameObject go = Instantiate(PlevPrefab);
            go.transform.position = (Vector2)Camera.main.transform.position;
            go.transform.position = (Vector2)go.transform.position + Random.insideUnitCircle*10f;
        }
    }
}