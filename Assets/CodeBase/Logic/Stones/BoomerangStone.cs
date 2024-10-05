using CodeBase.Logic.Attacks;
using CodeBase.Logic.Player;

namespace CodeBase.Logic.Stones
{
    class BoomerangStone : BaseStone
    {
        public Attack BoomerangAttack;
        public Attack BaseAttack;
        public PlayerController PlayerController;
        protected override void Deactivate()
        {
            PlayerController.SetAttack(BaseAttack);
        }

        protected override void Activate()
        {
            PlayerController.SetAttack(BoomerangAttack);
        }
    }
}