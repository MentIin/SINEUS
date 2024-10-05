using System.Collections.Generic;
using System.Linq;
using CodeBase.Infrastructure.Data.PlayerData;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Logic.Stones
{
    public abstract class BaseStone : MonoBehaviour
    {
        public GameData.MagicStonesTypes Type;
        
        private GameData _progressGameData;

        protected bool Active = false;
        protected GameData GameData => AllServices.Container.Single<PersistentProgressService>().Progress.GameData;
        
        private void Start()
        {
            _progressGameData = AllServices.Container.Single<PersistentProgressService>().Progress.GameData;
            _progressGameData.MagicStoneChanged += MagicStoneChanged;
            MagicStoneChanged();
            
            Initialize();
        }

        protected virtual void Initialize()
        {
            
        }
        private void OnDestroy()
        {
            _progressGameData.MagicStoneChanged -= MagicStoneChanged;
        }

        private void MagicStoneChanged()
        {
            List<GameData.MagicStonesTypes> magicStonesTypesList = new List<GameData.MagicStonesTypes>();

            foreach (var magicStoneSerializableData in _progressGameData.playerSlots)
            {
                magicStonesTypesList.Add(magicStoneSerializableData.Type);
            }
            
            if (magicStonesTypesList.Contains(Type) && !Active)
            {
                Active = true;
                Debug.Log("Magic stone is equipped - " + Type.ToString());
                Activate();

            }else if (!magicStonesTypesList.Contains(Type) && Active)
            {
                Debug.Log("Magic stone is off - " + Type.ToString());
                Active = false;
                Deactivate();
            }
        }

        protected abstract void Deactivate();
        protected abstract void Activate();

    }
}