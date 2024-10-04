using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Data;
using UnityEngine;

namespace CodeBase.Logic.Enemy.Chekers
{
    public class CheckIfSeeTeamInRadius : MonoBehaviour
    {
        public Team MyTeam;
        public LayerMask CanNotSeeThrough;
        public TriggerObserver TriggerObserver;

        private List<Collider2D> _colliders = new List<Collider2D>();
        
        private void Start()
        {
            TriggerObserver.TriggerEnter += TriggerObserverOnTriggerEnter;
            TriggerObserver.TriggerExit += TriggerObserverOnTriggerExit;
        }

        private void TriggerObserverOnTriggerExit(Collider2D obj)
        {
            if (_colliders.Contains(obj))
            {
                _colliders.Remove(obj);
            }
        }

        private void TriggerObserverOnTriggerEnter(Collider2D obj)
        {
            Health health = obj.GetComponent<Health>();
            if (health)
            {
                if (health.Team != MyTeam)
                {
                    
                    _colliders.Add(obj);
                }
            }
        }


        public List<Collider2D> GetColliders()
        {
            List<Collider2D> collider2Ds = new List<Collider2D>();
            foreach (var col in _colliders)
            {
                Vector2 direction = col.transform.position - transform.position;
                if (!Physics2D.Raycast(transform.position,
                    direction, direction.magnitude, CanNotSeeThrough))
                {
                    collider2Ds.Add(col);
                }
            }

            return collider2Ds;
        }

        public Collider2D GetCollider()
        {
            if (_colliders.Count == 0)
            {
                return null;
            }
            Collider2D res = _colliders[0];
            float dist = Single.PositiveInfinity;
            foreach (var col in GetColliders())
            {
                float sqrMagnitude = (col.transform.position - transform.position).sqrMagnitude;
                if (sqrMagnitude < dist)
                {
                    dist = sqrMagnitude;
                    res = col;
                }
            }

            return res;
        }
    }
}