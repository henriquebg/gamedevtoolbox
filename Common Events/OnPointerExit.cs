using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnPointerExit : MonoBehaviour, IPointerExitHandler
{
    [SerializeField] private UnityEvent onExit;

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            onExit.Invoke();
        }
    }
}
