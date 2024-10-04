using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

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
            BoomerangAttack=3,
        }
        public List<MagicStone> playerPocket = new List<MagicStone>();
        public List<Slot> playerSlots = new List<Slot>();

    }
}