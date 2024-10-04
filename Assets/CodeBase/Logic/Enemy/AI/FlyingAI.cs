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
                Vector2 force = col.transform.position - transform.position;

                if (force.magnitude < TargetDistance)
                {
                    AttackMelee.StartAttack();
                    return;
                }
                _totalForce += force.normalized * _characterData.maxSpeed * Time.deltaTime /3f;
                _totalForce = _totalForce - _totalForce*Time.deltaTime;
                
                CharacterController2D.Move(_totalForce);
            }
        }
    }
}