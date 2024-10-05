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
                float toWait;
                if (id >= Song.Timings.Count)
                {
                    toWait = 10000f;
                }
                else
                {
                    toWait = Song.Timings[id].AppearTime - sum;
                }
                
                sum += toWait;
                yield return new WaitForSeconds(toWait);

                print("spaned");
                Spawn( Song.Timings[id].PlevTime - Song.Timings[id].AppearTime);


                id++;
            }
        }

        private void Spawn(float time)
        {
            int dir = Random.Range(0, 2);

            Camera camera = Camera.main;
            GameObject go = Instantiate(PlevPrefab, camera.transform);

            Vector2 pos = Vector2.zero;
            
            // Calculate orthographic camera bounds
            float height = 2f * camera.orthographicSize;
            float width = height * camera.aspect;

            pos = camera.transform.position;
            pos -= new Vector2(width / 2, height / 2);

            float rotation = 0f;
            if (dir == 0)
            {
                pos += new Vector2(Random.Range(0, width),
                    height) ;

                rotation = 180;
            }else if (dir == 1)
            {
                pos += new Vector2(Random.Range(0, width),
                    0f) ;

                rotation = 000;
            }
            go.transform.position = pos;
            go.transform.eulerAngles = new Vector3(0f, 0f, rotation);
            
            
            go.GetComponent<Plev>().Construct(time);
        }
    }
}