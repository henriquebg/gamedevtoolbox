using UnityEngine;

namespace OriOpaStudio.AudioSystem
{
	[CreateAssetMenu(fileName = "New Audio Asset", menuName = "GameDev Toolbox/Audio Asset")]
	public class AudioAsset : ScriptableObject
	{
		[SerializeField] private bool loop = false;
		[SerializeField] private AudioClip clip;
		[SerializeField] private float volume = 1f;
		[SerializeField] private float pitch = 1f;

		public bool Loop => loop;
		public AudioClip Clip => clip;
		public float Volume => volume;
		public float Pitch => pitch;
	}
}