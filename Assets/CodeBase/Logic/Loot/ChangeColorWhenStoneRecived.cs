using CodeBase.Infrastructure.Data.PlayerData;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Logic.Loot
{
    public class ChangeColorWhenStoneRecived : MonoBehaviour
    {
        public StoneStaticData Data;
        public SpriteRenderer renderer;
        [SerializeField] private Color myGray = new Color(55,55,55,255);

        private GameData _progressGameData;

        private void Start()
        {
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
                renderer.color = myGray;
            }
        }

        private void OnDestroy()
        {
            _progressGameData.MagicStoneChanged -= MagicStoneChanged;
        }
    }
}