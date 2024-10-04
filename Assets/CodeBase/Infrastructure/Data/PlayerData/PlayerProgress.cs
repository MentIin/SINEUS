using System;

namespace CodeBase.Infrastructure.Data.PlayerData
{
    [Serializable]
    public class PlayerProgress
    {
        public SettingsData Settings;
        public TutorialData TutorialData;

        public GameData GameData;
        
        public bool HaveSave = false;
        
        
    }
}