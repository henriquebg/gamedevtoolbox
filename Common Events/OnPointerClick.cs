using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnPointerClick : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private UnityEvent onClick;
	[SerializeField] private bool isEnabled = true;

	public bool Enabled { get => isEnabled; set { isEnabled = value; } }

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		if (isEnabled && eventData.pointerDrag != null)
		{
			onClick.Invoke();
		}
	}
}
