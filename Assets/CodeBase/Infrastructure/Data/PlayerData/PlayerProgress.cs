using System;

namespace CodeBase.Infrastructure.Data.PlayerData
{
    [Serializable]
    public class PlayerProgress
    {
        public SettingsData Settings = new SettingsData();
        public TutorialData TutorialData = new TutorialData();

        public GameData GameData = new GameData();
        
        public bool HaveSave = false;
        
        
    }
}