using CodeBase.Logic.Attacks;
using CodeBase.Logic.Enemy.Chekers;
using UnityEngine;

namespace CodeBase.Logic.Enemy.AI
{
    public class SwordmanAI : MonoBehaviour
    {
        [SerializeField] private CheckIfSeePlayer CheckIfSeePlayer;
        [SerializeField] private CheckPlatformEnd CheckPlatformEnd;
        [SerializeField] private CharacterController2D Controller2D;
        [SerializeField] private Attack Attack;

        public float TargetDistance = 1f;
        
        private int direction = 1;

        private void Update()
        {
            int dir = CheckIfSeePlayer.Check();
            if (dir != 0)
            {
                if (CheckIfSeePlayer.HitDistance >= TargetDistance)
                {
                    direction = dir;
                }
                else
                {
                    direction = 0;
                    Attack.StartAttack();
                }
                
            }

            if (CheckPlatformEnd.Check())
            {
                direction *= -1;
            }
            Controller2D.Walk(direction);
        }
    }
}