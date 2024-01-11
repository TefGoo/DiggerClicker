using UnityEngine;
using UnityEngine.EventSystems;

public class DraggablePanel : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform panelRectTransform;
    private Vector2 pointerOffset;
    private float minY = -200f;
    private float maxY = 150f;

    void Start()
    {
        panelRectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Calculate the offset between the panel's position and the mouse position
        RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform, eventData.position, eventData.pressEventCamera, out pointerOffset);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (panelRectTransform == null)
            return;

        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out localPointerPosition))
        {
            // Calculate the new y position based on the mouse position and the offset
            float newY = localPointerPosition.y - pointerOffset.y;

            // Apply limits to the new y position
            newY = Mathf.Clamp(newY, minY, maxY);

            // Set the panel's position
            panelRectTransform.localPosition = new Vector2(panelRectTransform.localPosition.x, newY);
        }
    }
}
