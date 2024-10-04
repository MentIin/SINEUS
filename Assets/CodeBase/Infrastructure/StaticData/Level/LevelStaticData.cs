using UnityEditor;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData.Level
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level", order = 0)]
    public class LevelStaticData : ScriptableObject
    {
        public SceneAsset Scene;
    }
}