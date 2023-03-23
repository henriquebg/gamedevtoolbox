using UnityEngine;

namespace OriOpaStudio.Utilities
{
	public class ChildrenShuffler : MonoBehaviour
	{
		public void Shuffle()
		{
			var childCount = transform.childCount;

			for (int i = 0; i < childCount; i++ )
			{
				var newIndex = RNG.GetRandomIntBetween(0, childCount - 1);
				transform.GetChild(i).SetSiblingIndex(newIndex);
			}
		}
	}
}