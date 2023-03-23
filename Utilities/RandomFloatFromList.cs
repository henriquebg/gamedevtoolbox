using UnityEngine;

namespace OriOpaStudio.Utilities
{
	[CreateAssetMenu(fileName = "New Float List", menuName = "Game Dev Toolbox/Utilities")]
	public class RandomFloatFromList : ScriptableObject
	{
		[SerializeField] private float[] valuesToPick;

		private float value;
		public float Value 
		{ 
			get 
			{ 
				return valuesToPick[RNG.GetRandomIntBetween(0, valuesToPick.Length - 1)]; 
			} 
		}
	}
}