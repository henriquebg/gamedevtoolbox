using UnityEngine;
using UnityEngine.Events;

public class OnStart : MonoBehaviour
{
	[SerializeField] private UnityEvent executeOnStart;

	void Start()
	{
		executeOnStart.Invoke();
	}
}