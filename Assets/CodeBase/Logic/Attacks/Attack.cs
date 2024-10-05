using System;
using CodeBase.Infrastructure.Data;
using UnityEngine;

namespace CodeBase.Logic.Attacks
{
    public abstract class Attack : MonoBehaviour
    {
        public Team Team;
        public Action AttackStarted;
        /// <returns>Return true if can attack and fall if can not(reload, etc)</returns>
        public abstract bool StartAttack();

        protected void InvokeStarted()
        {
            AttackStarted?.Invoke();
        }
    }

    
}