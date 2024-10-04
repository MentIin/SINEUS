using CodeBase.Logic.Enemy.Chekers;
using UnityEngine;

namespace CodeBase.Logic.Enemy.AI
{
    public class SwordmanAI : MonoBehaviour
    {
        [SerializeField] private CheckIfSeePlayer CheckIfSeePlayer;
        [SerializeField] private CheckPlatformEnd CheckPlatformEnd;
        [SerializeField] private CharacterController2D Controller2D;

        public float TargetDistance = 1f;
        
        private int direction = 1;

        private void Update()
        {
            float dir = CheckIfSeePlayer.Check();
            if (dir != 0)
            {
                if (CheckIfSeePlayer.HitDistance >= TargetDistance)
                {
                    Controller2D.Walk(dir);
                }
                else
                {
                    Controller2D.Walk(0f);
                }
                
            }
            else
            {
                if (CheckPlatformEnd.Check())
                {
                    direction *= -1;
                }
                Controller2D.Walk(direction);
            }
        }
    }
}