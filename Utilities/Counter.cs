using UnityEngine;
using UnityEngine.Events;

namespace OriOpaStudio.Utilities
{
	public class Counter : MonoBehaviour
	{
		[SerializeField] private int whenReach = 0;
		[SerializeField] private UnityEvent triggersEvent;
		private int counter = 0;

		public void Increase()
		{
			counter++;

			if (counter == whenReach)
				triggersEvent.Invoke();
		}
	}
}