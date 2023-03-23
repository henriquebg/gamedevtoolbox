using UnityEngine;
using UnityEngine.EventSystems;

public class FitToSlot : MonoBehaviour, IDropHandler
{
	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null)
		{
			eventData.pointerDrag.transform.position = transform.position;
		}
	}
}
