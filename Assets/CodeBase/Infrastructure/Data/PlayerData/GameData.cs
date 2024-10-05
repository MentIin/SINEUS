using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Data.PlayerData
{
    [Serializable]
    public class GameData
    {
        public List<MagicStoneSerializableData> playerPocket = new List<MagicStoneSerializableData>();
        public MagicStoneSerializableData[] playerSlots = new MagicStoneSerializableData[5];

        public Action MagicStoneChanged;
        
        
        public enum MagicStonesTypes
        {
            Null=0,
            MeleeAttack=1,
            SingleShot=2,
            ZoneSplash=3,
            BoomerangAttack=4,
            BubbleAttack=5,
            Gravity=6,
            Fire=7,
            Jump=8,
        }

        public void ChangePlace(MagicStoneSerializableData activeStoneStoneType, int activeStonePlace, int newPlace)
        {
            
            if (activeStonePlace == -1)
            {
                if (newPlace == -1) return;
                playerPocket.Remove(activeStoneStoneType);
                playerSlots[newPlace] = activeStoneStoneType;
            }
            else
            {
                if (newPlace == -1)
                {
                    playerSlots[activeStonePlace] = new MagicStoneSerializableData
                    {
                        Type = MagicStonesTypes.Null
                    };
                    playerPocket.Add(activeStoneStoneType);
                }
                else
                {
                    playerSlots[activeStonePlace] =  new MagicStoneSerializableData
                    {
                        Type = MagicStonesTypes.Null
                    };
                    playerSlots[newPlace] = activeStoneStoneType;
                }
               
            }
            MagicStoneChanged?.Invoke();
        }

        public void Use(MagicStonesTypes type)
        {
            foreach (var stoneSerializableData in playerSlots)
            {
                if (stoneSerializableData.Type == type)
                {
                    Debug.Log(stoneSerializableData.Usages);
                    stoneSerializableData.Usages--;
                    
                    MagicStoneChanged?.Invoke();
                    return;
                }
            }
        }

        public int UsagesLeftSlots(MagicStonesTypes type)
        {
            foreach (var stoneSerializableData in playerSlots)
            {
                if (stoneSerializableData.Type == type)
                {
                    return stoneSerializableData.Usages;
                }
            }

            Debug.LogWarning("Not found");
            return -1;
        }
    }

    [Serializable]
    public class MagicStoneSerializableData
    {
        public GameData.MagicStonesTypes Type;
        public int Usages;
    }
}