namespace CodeBase.Logic.Stones
{
    class JumpStone : BaseStone
    {
        public CharacterData Data;
        public CharacterController2D Controller2D;
        
        protected override void Initialize()
        {
            
        }

        private void OnDestroy()
        {
            Controller2D.Jumped -= Jumped;
        }

        private void Jumped()
        {
            GameData.Use(Type);
            if (GameData.UsagesLeftSlots(Type) == 0)
            {
                Active = false;
                Deactivate();
            }
        }

        protected override void Deactivate()
        {
            Controller2D.Jumped -= Jumped;
            Data.maxJumpHeight /= 2;
        }

        protected override void Activate()
        {
            Controller2D.Jumped += Jumped;
            Data.maxJumpHeight *= 2;
        }
    }
}