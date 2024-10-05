using System;
using CodeBase.Logic.Attacks;
using CodeBase.Logic.Player;
using UnityEngine.Serialization;

namespace CodeBase.Logic.Stones
{
    class ChangeAttackStone : BaseStone
    {
        [FormerlySerializedAs("BoomerangAttack")] public Attack StoneAttack;
        public Attack BaseAttack;
        public PlayerController PlayerController;

        protected override void Initialize()
        {
            StoneAttack.AttackStarted += AttackStarted;
        }

        private void OnDestroy()
        {
            StoneAttack.AttackStarted -= AttackStarted;
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
            PlayerController.SetAttack(BaseAttack);
        }

        protected override void Activate()
        {
            PlayerController.SetAttack(StoneAttack);
        }
    }
}