using System;
using CodeBase.Infrastructure.Data.PlayerData;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Logic.Loot
{
    public class StoneReciver : MonoBehaviour
    {
        public StoneStaticData Data;
        public SpriteRenderer renderer;

        private GameData _progressGameData;

        private void Start()
        {
            renderer.sprite = Data.Icon;
            _progressGameData = AllServices.Container.Single<PersistentProgressService>().Progress.GameData;
            
            _progressGameData.MagicStoneChanged += MagicStoneChanged;
            MagicStoneChanged();
        }

        private void MagicStoneChanged()
        {
            if (_progressGameData.Recived.Contains(Data.Type))
            {
                renderer.color = Color.white;
            }
            else
            {
                renderer.color = Color.black;
            }
        }

        private void OnDestroy()
        {
            _progressGameData.MagicStoneChanged -= MagicStoneChanged;
        }

        public void Recive()
        {
            _progressGameData.ReciveFromInventory(Data.Type);
        }
    }
}