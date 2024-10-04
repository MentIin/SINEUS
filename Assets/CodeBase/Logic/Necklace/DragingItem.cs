using UnityEngine;
using UnityEngine.EventSystems;

public class DragingItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform m_RectTransform;
    private Canvas m_Canvas;
    private CanvasGroup m_CanvasGroup;
    public Vector3 start_pos;
    private void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_Canvas = GetComponentInParent<Canvas>();
        m_CanvasGroup = GetComponentInParent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = m_RectTransform.parent;
        slotTransform.SetAsLastSibling();
        m_CanvasGroup.blocksRaycasts = false;
        start_pos = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        m_RectTransform.anchoredPosition += eventData.delta / m_Canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = start_pos;
        m_CanvasGroup.blocksRaycasts = true;
    }
}
