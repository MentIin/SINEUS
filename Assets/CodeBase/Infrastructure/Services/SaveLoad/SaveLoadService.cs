using CodeBase.Infrastructure.Data;
using CodeBase.Infrastructure.Data.PlayerData;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        private readonly PersistentProgressService _progressService;

        public SaveLoadService(PersistentProgressService progressService)
        {
            _progressService = progressService;
        }

        public void SaveProgress()
        {
            Debug.Log("Saved");
            PlayerPrefs.SetString(ProgressKey, _progressService.Progress.AsJson());
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();
        }
    }
}