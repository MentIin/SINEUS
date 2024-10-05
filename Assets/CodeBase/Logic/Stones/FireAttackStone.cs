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
            AttackBoomerang.AttackStarted += AttackStarted;
            AttackMelee.AttackStarted += AttackStarted;
        }

        private void OnDestroy()
        {
            AttackBoomerang.AttackStarted -= AttackStarted;
            AttackMelee.AttackStarted -= AttackStarted;
        }

        private void AttackStarted()
        {
            if (!Active) return;
            GameData.Use(Type);
            if (GameData.UsagesLeftSlots(Type) <= 0)
            {
                Deactivate();
            }
        }
        protected override void Deactivate()
        {
            AttackMelee.FirePrefab = null;
            AttackBoomerang.FirePrefab = null;
        }

        protected override void Activate()
        {
            AttackMelee.FirePrefab = FirePrefab;
            AttackBoomerang.FirePrefab = FirePrefab;
        }
    }
}