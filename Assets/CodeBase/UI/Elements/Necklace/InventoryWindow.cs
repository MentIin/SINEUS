using System;
using CodeBase.Infrastructure.Data.PlayerData;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

namespace CodeBase.UI.Elements.Necklace
{
    public class InventoryWindow : MonoBehaviour
    {
        public Slot[] slots;
        public RectTransform Pocket;
        public GameObject DragItemPrefab;
        
        
        private PersistentProgressService persistentProgressService;
        private StaticDataService staticDataService;

        public void Start()
        {
            persistentProgressService = AllServices.Container.Single<PersistentProgressService>();
            staticDataService = AllServices.Container.Single<StaticDataService>();

            UpdatePocket();
            UpdateNeckplace();
            
            persistentProgressService.Progress.GameData.MagicStoneChanged += MagicStoneChanged;
        }

        private void OnDestroy()
        {
            persistentProgressService.Progress.GameData.MagicStoneChanged -= MagicStoneChanged;

        }

        private void MagicStoneChanged()
        {
            UpdateNeckplace();
            UpdatePocket();
        }

        private void UpdateNeckplace()
        {
            int i=0;
            foreach (var slot in slots)
            {
                if (slot.activeStone != null)
                {
                    DestroyImmediate(slot.activeStone.gameObject);
                    slot.activeStone = null;
                }
            }
            
            foreach (var magicStoneType in persistentProgressService.Progress.GameData.playerSlots)
            {
                
                if (magicStoneType == GameData.MagicStonesTypes.Null)
                {
                    i++;
                    continue;
                }
                
                
                StoneStaticData staticData = staticDataService.ForStone(magicStoneType);

                
                GameObject go = Instantiate(DragItemPrefab, slots[i].transform);
                slots[i].activeStone = go.GetComponent<MagicStone>();
                go.transform.localPosition = Vector3.zero;
                go.GetComponent<MagicStone>().place = i;
                go.GetComponent<MagicStone>().stoneType = magicStoneType;
                go.GetComponentInChildren<Image>().sprite = staticData.Icon;
                i++;
            }
        }

        private void UpdatePocket()
        {
            foreach (var stone in Pocket.GetComponentsInChildren<MagicStone>())
            {
                Destroy(stone.gameObject);
            }
            
            foreach (var magicStoneType in persistentProgressService.Progress.GameData.playerPocket)
            {
                StoneStaticData staticData = staticDataService.ForStone(magicStoneType);

                GameObject go = Instantiate(DragItemPrefab, Pocket);
                go.GetComponent<MagicStone>().place = -1;
                go.GetComponent<MagicStone>().stoneType = magicStoneType;
                go.GetComponentInChildren<Image>().sprite = staticData.Icon;
            }
        }
    }
}