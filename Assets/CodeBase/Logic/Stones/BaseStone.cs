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

        private bool _active = false;
        
        private void Start()
        {
            _progressGameData = AllServices.Container.Single<PersistentProgressService>().Progress.GameData;
            _progressGameData.MagicStoneChanged += MagicStoneChanged;
            MagicStoneChanged();
        }

        private void OnDestroy()
        {
            _progressGameData.MagicStoneChanged -= MagicStoneChanged;
        }

        private void MagicStoneChanged()
        {
            if (_progressGameData.playerSlots.Contains(Type) && !_active)
            {
                _active = true;
                Debug.Log("Magic stone is equipped - " + Type.ToString());
                Activate();

            }else if (!_progressGameData.playerSlots.Contains(Type) && _active)
            {
                Debug.Log("Magic stone is off - " + Type.ToString());
                _active = false;
                Deactivate();
            }
        }

        protected abstract void Deactivate();
        protected abstract void Activate();

    }
}