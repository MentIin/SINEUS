using System;
using CodeBase.Logic.Enemy.Chekers;
using UnityEngine;

namespace CodeBase.Logic.Enemy.AI
{
    public class FlyingAI : MonoBehaviour
    {
        public CheckIfSeeTeamInRadius CheckIfSeeTeamInRadius;
        public CharacterController2D CharacterController2D;


        private void Update()
        {
            Collider2D col = CheckIfSeeTeamInRadius.GetCollider();
            if (col != null)
            {
                Vector2 force = col.transform.position - transform.position;
                CharacterController2D.ApplyForce(force.normalized * 10);
            }
        }
    }
}