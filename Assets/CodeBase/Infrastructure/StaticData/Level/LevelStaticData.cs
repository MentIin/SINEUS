using NaughtyAttributes;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData.Level
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level", order = 0)]
    public class LevelStaticData : ScriptableObject
    {
        [Scene] public string Scene;
    }
}