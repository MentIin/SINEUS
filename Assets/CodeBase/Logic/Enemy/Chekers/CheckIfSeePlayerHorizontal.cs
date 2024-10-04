using System;
using CodeBase.Infrastructure.Data;
using UnityEngine;

namespace CodeBase.Logic.Enemy.Chekers
{
    public class CheckIfSeePlayerHorizontal : MonoBehaviour
    {
        [SerializeField] private LayerMask cannotSeeThroughMask;
        [SerializeField] private float _distance=30f;

        
        public float HitDistance { get; private set; }
        public int Check()
        {
            Vector2 direction = Vector2.right;
            if (CheckDir(direction)) return 1;
            
            direction = Vector2.left;
            if (CheckDir(direction)) return -1;


            return 0;
        }

        private bool CheckDir(Vector2 direction)
        {
            RaycastHit2D[] hits2D = Physics2D.RaycastAll(transform.position, direction,
                _distance, cannotSeeThroughMask);
            Health health;
            foreach (var hit2D in hits2D)
            {
                if (hit2D.collider)
                {
                    if (hit2D.collider.TryGetComponent(out health))
                    {
                        if (health.Team == Team.Player)
                        {
                            HitDistance = hit2D.distance;
                            return true;
                        }
                    }
                    else
                    {
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }
        
    }
}