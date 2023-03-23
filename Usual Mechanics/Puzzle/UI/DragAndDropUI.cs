using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropUI : MonoBehaviour, IDragHandler, IInitializePotentialDragHandler
{
    [SerializeField] private bool isEnabled = true;
    private Canvas canvas;
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isEnabled)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        eventData.useDragThreshold = false;
    }
}
