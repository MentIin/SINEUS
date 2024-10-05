using CodeBase.Logic.Attacks;
using CodeBase.Logic.Enemy.Chekers;
using UnityEngine;

namespace CodeBase.Logic.Enemy.AI
{
    public class RiderAI : MonoBehaviour
    {
        [SerializeField] private CheckIfSeePlayerHorizontal checkIfSeePlayerHorizontal;
        [SerializeField] private CheckPlatformEnd CheckPlatformEnd;
        [SerializeField] private CharacterController2D Controller2D;
        [SerializeField] private Attack Attack;
        
        
        private int direction = 0;

        private float _stun = 0f;

        public bool Stunned
        {
            get => _stun > 0;
        }

        private void Update()
        {
            if (_stun > 0)
            {
                _stun -= Time.deltaTime;
                Controller2D.Walk(0f);
                return;
            }
            
            
            if (direction == 0) direction = checkIfSeePlayerHorizontal.Check();
            else
            {
                Attack.StartAttack();
                if (CheckPlatformEnd.Check() && Controller2D.Grounded)
                {
                    Debug.Log("stun");
                    Controller2D.ApplyForce(Vector2.up*10);
                    _stun += 3f;
                    direction = 0;
                }
            }
            Controller2D.Walk(direction);
        }
    }
}