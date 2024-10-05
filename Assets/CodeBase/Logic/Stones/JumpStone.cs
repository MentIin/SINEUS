namespace CodeBase.Logic.Stones
{
    class JumpStone : BaseStone
    {
        public CharacterData Data;

        protected override void Deactivate()
        {
            Data.maxJumpHeight /= 2;
        }

        protected override void Activate()
        {
            Data.maxJumpHeight *= 2;
        }
    }
}