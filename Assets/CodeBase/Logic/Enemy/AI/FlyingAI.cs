using System;
using CodeBase.Logic.Attacks;
using CodeBase.Logic.Enemy.Chekers;
using UnityEngine;

namespace CodeBase.Logic.Enemy.AI
{
    public class FlyingAI : MonoBehaviour
    {
        public CheckIfSeeTeamInRadius CheckIfSeeTeamInRadius;
        public CharacterController2D CharacterController2D;
        public AttackMelee AttackMelee;
        
        public float TargetDistance = 1f;
        
        private CharacterData _characterData;


        private Vector2 _totalForce;
        private void Awake()
        {
            _characterData = CharacterController2D.GetComponent<CharacterData>();
            
        }

        private void Update()
        {
            Collider2D col = CheckIfSeeTeamInRadius.GetCollider();
            if (col != null)
            {
                CharacterController2D.SetGravityScale(0f);
                CharacterController2D.ignoreGravity = true;
                Vector3 target = col.transform.position;
                Follow(target);
            }
            else
            {
                CharacterController2D.ignoreGravity = false;
                CharacterController2D.SetGravityScale(0.1f);
            }
            
        }

        private void Follow(Vector3 target)
        {
            Vector2 force = target - transform.position;

            if (force.magnitude < TargetDistance)
            {
                AttackMelee.StartAttack();
                return;
            }

            Vector2 newForce = force.normalized * _characterData.maxSpeed * Time.deltaTime / 3f;
            
            _totalForce += newForce;
            _totalForce = _totalForce - _totalForce * Time.deltaTime;
            if (_totalForce.y < -0.1f)
            {
                _totalForce.y = -0.1f;
            }

            CharacterController2D.ApplyForce(_totalForce);
        }
    }
}