using System;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.UI.Elements.Necklace
{
    public class Slot : MonoBehaviour, IDropHandler
    {
        public MagicStone activeStone;
        public int place = 0;
        private PersistentProgressService _progressService;

        private void Start()
        {
            _progressService = AllServices.Container.Single<PersistentProgressService>();
        }

        public void OnDrop(PointerEventData eventData)
        {
            var otherItemTransform = eventData.pointerDrag.transform;
            if (otherItemTransform.GetComponent<DragingItem>() != null && otherItemTransform.GetComponent<MagicStone>()!=null)
            {
                if (activeStone == null)
                {
                    activeStone = otherItemTransform.GetComponent<MagicStone>();
                    /*
                    DragingItem otherItem = otherItemTransform.GetComponent<DragingItem>();
                    otherItem.transform.SetParent(transform);
                    otherItem.start_pos = Vector3.zero;
                    otherItem.transform.localPosition = Vector3.zero;*/

                    
                    _progressService.Progress.GameData.ChangePlace(activeStone.stoneType, activeStone.place, place);
                    
                    
                    
                }
            }
        }
    }
}
