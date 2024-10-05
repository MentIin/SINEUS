using CodeBase.Infrastructure.Data.PlayerData;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.Elements.Necklace
{
    public class MagicStone : MonoBehaviour
    {
        public TextMeshProUGUI Usages;
        public MagicStoneSerializableData stoneData
        {
            set
            {
                _stoneData = value;
                Usages.text = value.Usages.ToString();
            }
            get => _stoneData;

        }

        private MagicStoneSerializableData _stoneData;
        public int place=-1;
    }
}
