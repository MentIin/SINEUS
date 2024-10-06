using System;
using System.Collections;
using CodeBase.Infrastructure.Data;
using CodeBase.Infrastructure.Data.PlayerData;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Logic.Player;
using Unity.VisualScripting;
using UnityEngine;
using Object = System.Object;
using Random = UnityEngine.Random;


namespace CodeBase.Logic.Enemy.Boss
{
    public class BossBrain : MonoBehaviour
    {
        public GameObject LooseCanvas;
        public SongData Song;
        public GameObject PlevPrefab;

        private void Start()
        {
            StartCoroutine(SpawnPlevs());
            StartCoroutine(CheckWin());
        }

        private IEnumerator CheckWin()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                bool f = true;
                foreach (Health health in FindObjectsByType<Health>(FindObjectsSortMode.None))
                {
                    if (health.Team == Team.Enemy)
                    {
                        f = false;
                        break;
                    }
                }

                if (f)
                {
                    Win();
                }
            }
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
                    yield return new WaitForSeconds(Song.Duration - sum);
                    break;
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

            StartCoroutine(Loose());

        }

        private IEnumerator Loose()
        {
            GameObject o = Instantiate(LooseCanvas);

            PlayerController[] findObjectsByType = FindObjectsByType<PlayerController>(FindObjectsSortMode.None);

            //findObjectsByType[0].gameObject.SetActive(false);

            findObjectsByType[0].GetComponent<CharacterController2D>().Walk(0);
            findObjectsByType[0].GetComponent<CharacterController2D>().enabled = false;
            yield return new WaitForSeconds(3f);
            findObjectsByType[0].GetComponent<Health>().TakeDamage(9999);
            Destroy(o);
        }

        private void Win()
        {
            StopAllCoroutines();
            GameData data = AllServices.Container.Single<PersistentProgressService>().Progress.GameData;

            data.Recive(GameData.MagicStonesTypes.BossHead);
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