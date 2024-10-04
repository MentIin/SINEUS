using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    private MagicStone activeStone;
    private Necklace necklace;
    private void Start()
    {
        necklace = Necklace.Container;
    }

    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        if (otherItemTransform.GetComponent<DragingItem>() != null && otherItemTransform.GetComponent<MagicStone>()!=null)
        {
            if (activeStone == null)
            {
                activeStone = otherItemTransform.GetComponent<MagicStone>();
                OnActivate();
                DragingItem otherItem = otherItemTransform.GetComponent<DragingItem>();
                otherItem.transform.SetParent(transform);
                otherItem.start_pos = Vector3.zero;
                otherItem.transform.localPosition = Vector3.zero;
            }
        }
    }
    private void OnActivate()
    {
        bool hasStone = false;
        foreach(MagicStone stone in necklace.activeStones)
        {
            if (stone == activeStone)
            {
                hasStone = true;
                break;
            }
        }
        if (!hasStone)
        {
            necklace.activeStones.Add(activeStone);
            activeStone.Activate();
        }
    }
}
