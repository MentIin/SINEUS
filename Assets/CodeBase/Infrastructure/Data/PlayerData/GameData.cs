using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.UI.Elements.Necklace;
using UnityEngine;

namespace CodeBase.Infrastructure.Data.PlayerData
{
    [Serializable]
    public class GameData
    {
        public List<MagicStonesTypes> playerPocket = new List<MagicStonesTypes>();
        public MagicStonesTypes[] playerSlots = new MagicStonesTypes[5];

        public Action MagicStoneChanged;
        
        
        public enum MagicStonesTypes
        {
            Null=0,
            MeleeAttack=1,
            SingleShot=2,
            ZoneSplash=3,
            BoomerangAttack=4,
        }

        public void ChangePlace(MagicStonesTypes activeStoneStoneType, int activeStonePlace, int newPlace)
        {
            if (activeStonePlace == -1)
            {
                playerPocket.Remove(activeStoneStoneType);
                playerSlots[newPlace] = activeStoneStoneType;
            }
            else
            {
                playerSlots[activeStonePlace] = MagicStonesTypes.Null;
                playerSlots[newPlace] = activeStoneStoneType;
            }
            MagicStoneChanged?.Invoke();
        }
    }
}