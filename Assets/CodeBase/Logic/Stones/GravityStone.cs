using System;

namespace CodeBase.Logic.Stones
{
    class GravityStone : BaseStone
    {
        public CharacterController2D CharacterController;
        protected override void Deactivate()
        {
            CharacterController.SetGravityScale(1f);
        }

        protected override void Activate()
        {
            CharacterController.SetGravityScale(-1f);
        }
    }
}