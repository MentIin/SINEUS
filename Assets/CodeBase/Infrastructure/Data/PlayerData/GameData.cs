using System;

namespace CodeBase.Infrastructure.Data.PlayerData
{
    [Serializable]
    public class GameData
    {
        public enum MagicStonesTypes
        {
            MeleeAttack=0,
            SingleShot=1,
            ZoneSplash=2,
        }
    }
}