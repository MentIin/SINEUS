﻿using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Data.PlayerData
{
    [Serializable]
    public class GameData
    {
        public int LastLevel=1;
        public List<MagicStoneSerializableData> playerPocket = new List<MagicStoneSerializableData>();
        public MagicStoneSerializableData[] playerSlots = new MagicStoneSerializableData[5];


        public List<MagicStonesTypes> Looted= new List<MagicStonesTypes>();
        public List<MagicStonesTypes> Recived= new List<MagicStonesTypes>();
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
            
            BossHead=10,
        }

        public void ChangePlace(MagicStoneSerializableData activeStoneStoneType, int activeStonePlace, int newPlace)
        {
            
            if (activeStonePlace == -1)
            {
                if (newPlace == -1) return;
                
                
                playerPocket.Remove(activeStoneStoneType);

                if (activeStoneStoneType.Type == MagicStonesTypes.BoomerangAttack ||
                    activeStoneStoneType.Type == MagicStonesTypes.BubbleAttack ||
                    activeStoneStoneType.Type == MagicStonesTypes.ZoneSplash)
                {
                    foreach (var data in playerSlots)
                    {
                        if (data.Type == MagicStonesTypes.BoomerangAttack ||
                            data.Type == MagicStonesTypes.BubbleAttack ||
                            data.Type == MagicStonesTypes.ZoneSplash)
                        {
                            return;
                        }
                    }
                }
                
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

        public void Spend(MagicStonesTypes type)
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

        public void Loot(StoneStaticData staticData)
        {
            Looted.Add(staticData.Type);
            playerPocket.Add(new MagicStoneSerializableData
            {
                Type = staticData.Type,
                Usages = staticData.Usages,
            });
            MagicStoneChanged?.Invoke();
        }

        public void ReciveFromInventory(MagicStonesTypes type)
        {
            foreach (var serializableData in playerPocket)
            {
                if (serializableData.Type == type)
                {
                    playerPocket.Remove(serializableData);
                    Recived.Add(serializableData.Type);
                    MagicStoneChanged?.Invoke();
                    return;
                }
            }

            for (int i = 0; i < playerSlots.Length; i++)
            {
                if (playerSlots[i].Type == type)
                {
                    playerSlots[i] = new MagicStoneSerializableData {Type = MagicStonesTypes.Null};
                    Recived.Add(type);
                    MagicStoneChanged?.Invoke();
                    return;
                }
            }
        }

        public void Recive(MagicStonesTypes type)
        {
            if (Recived.Contains(type)) return;
            
            Recived.Add(type);
            MagicStoneChanged?.Invoke();
        }
    }

    [Serializable]
    public class MagicStoneSerializableData
    {
        public GameData.MagicStonesTypes Type;
        public int Usages;
    }
}