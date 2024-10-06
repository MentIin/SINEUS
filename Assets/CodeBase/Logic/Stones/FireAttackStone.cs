using CodeBase.Logic.Attacks;
using UnityEngine;

namespace CodeBase.Logic.Stones
{
    class FireAttackStone : BaseStone
    {

        public GameObject FirePrefab;
        public AttackBoomerang AttackBoomerang;
        public AttackMelee AttackMelee;
        
        protected override void Initialize()
        {
            
        }

        private void OnDestroy()
        {
            AttackBoomerang.AttackStarted -= AttackStarted;
            AttackMelee.AttackStarted -= AttackStarted;
        }

        private void AttackStarted()
        {
            if (!Active) return;
            GameData.Spend(Type);
            if (GameData.UsagesLeftSlots(Type) <= 0)
            {
                Deactivate();
            }
        }
        protected override void Deactivate()
        {
            OnDestroy();
            AttackMelee.FirePrefab = null;
            AttackBoomerang.FirePrefab = null;
        }

        protected override void Activate()
        {
            AttackBoomerang.AttackStarted += AttackStarted;
            AttackMelee.AttackStarted += AttackStarted;
            AttackMelee.FirePrefab = FirePrefab;
            AttackBoomerang.FirePrefab = FirePrefab;
        }
    }
}