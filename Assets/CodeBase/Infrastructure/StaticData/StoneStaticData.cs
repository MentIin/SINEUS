using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Data.PlayerData;
using CodeBase.UI.Services;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
    [Serializable]
    [CreateAssetMenu(fileName = "StoneStaticData", menuName = "StaticData/StoneStaticData", order = 0)]
    public class StoneStaticData : ScriptableObject
    {
        public GameData.MagicStonesTypes Type;
        public Sprite Icon;
    }
}