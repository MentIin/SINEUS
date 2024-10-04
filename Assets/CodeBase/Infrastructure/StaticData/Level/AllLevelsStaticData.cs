using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData.Level
{
    [CreateAssetMenu(fileName = "AllLevelsStaticData", menuName = "StaticData/AllLevels", order = 0)]
    public class AllLevelsStaticData : ScriptableObject
    {
        public List<LevelStaticData> Levels;
    }
}