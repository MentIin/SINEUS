using CodeBase.Logic.Attacks;
using UnityEngine;

namespace CodeBase.Logic.Stones
{
    class FireAttackStone : BaseStone
    {

        public GameObject FirePrefab;
        public AttackBoomerang AttackBoomerang;
        public AttackMelee AttackMelee;
        
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