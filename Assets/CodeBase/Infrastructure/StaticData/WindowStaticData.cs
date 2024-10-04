using System;
using System.Collections.Generic;
using CodeBase.UI.Services;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
    [Serializable]
    [CreateAssetMenu(fileName = "WindowsStaticData", menuName = "StaticData/WindowsStaticData", order = 0)]
    public class WindowsStaticData : ScriptableObject
    {
        public List<WindowConfig> WindowConfigs;
    }
}