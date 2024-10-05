using UnityEngine;

namespace CodeBase.Logic.Stones
{
    class GravityStone : BaseStone
    {
        public CharacterController2D CharacterController;
        protected override void Deactivate()
        {
            CharacterController.SetGravityScale(1f);
            CharacterController.transform.eulerAngles = new Vector3(0f, CharacterController.transform.eulerAngles.y,
                0f);
        }

        protected override void Activate()
        {
            CharacterController.SetGravityScale(-1f);
            CharacterController.transform.eulerAngles = new Vector3(0f, CharacterController.transform.eulerAngles.y,
                180f);
        }
    }
}