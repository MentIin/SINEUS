using CodeBase.Logic.Attacks;
using CodeBase.Logic.Enemy.Chekers;
using UnityEngine;

namespace CodeBase.Logic.Enemy.AI
{
    public class SwordmanAI : MonoBehaviour
    {
        [SerializeField] private CheckIfSeePlayerHorizontal checkIfSeePlayerHorizontal;
        [SerializeField] private CheckPlatformEnd CheckPlatformEnd;
        [SerializeField] private CharacterController2D Controller2D;
        [SerializeField] private Attack Attack;

        public float TargetDistance = 1f;
        
        private int direction = 1;

        private void Update()
        {
            int dir = checkIfSeePlayerHorizontal.Check();
            if (dir != 0)
            {
                if (checkIfSeePlayerHorizontal.HitDistance >= TargetDistance || dir != transform.right.x)
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