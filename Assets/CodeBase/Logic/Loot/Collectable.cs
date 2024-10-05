using System;
using CodeBase.Infrastructure.Data.PlayerData;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Logic.Loot
{
    public class Collectable : MonoBehaviour
    {
        public StoneStaticData StaticData;
        public SpriteRenderer Renderer;
        
        private GameData _progressGameData;

        private void Start()
        {
            _progressGameData = AllServices.Container.Single<PersistentProgressService>().Progress.GameData;

            if (_progressGameData.Looted.Contains(StaticData.Type))
            {
                Destroy(this.gameObject);
            }

            Renderer.sprite = StaticData.Icon;
        }

        public void Loot()
        {
            Destroy(this.gameObject);
            _progressGameData.Loot(StaticData);
        }
    }
}