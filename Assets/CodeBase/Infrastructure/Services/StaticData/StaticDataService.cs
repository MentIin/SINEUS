using System.Collections.Generic;
using System.Linq;
using CodeBase.Infrastructure.Data.PlayerData;
using CodeBase.Infrastructure.StaticData;
using CodeBase.Infrastructure.StaticData.Level;
using CodeBase.UI.Services;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService
    {
        private AllLevelsStaticData _levelsData;
        private Dictionary<WindowType, WindowConfig> _windowData;

        private static readonly string LevelsStaticData = "StaticData/Levels/AllLevelsStaticData";
        private static readonly string WindowsStaticData = "StaticData/UI/WindowsStaticData";
        public AllLevelsStaticData AllLevels;
        private Dictionary<GameData.MagicStonesTypes, StoneStaticData> _stoneData;


        public void Load()
        {
            LoadLevelsData();
            LoadWindowsData();
            AllLevels = Resources.Load<AllLevelsStaticData>(LevelsStaticData);
            _stoneData = Resources.LoadAll<StoneStaticData>("StaticData/Stones")
                .ToDictionary(x => x.Type,
                    x => x);

        }

        private void LoadWindowsData()
        {
            _windowData = Resources.Load<WindowsStaticData>(WindowsStaticData).WindowConfigs
                .ToDictionary(x => x.WindowType, x => x);
        }

        private void LoadLevelsData() => _levelsData = Resources.Load<AllLevelsStaticData>(LevelsStaticData);


        public WindowConfig ForWindow(WindowType type)
            => _windowData.TryGetValue(type, out WindowConfig config)
                ? config
                : null;



        public StoneStaticData ForStone(GameData.MagicStonesTypes type)
            => _stoneData.TryGetValue(type, out StoneStaticData config)
                ? config
                : null;
    }
}