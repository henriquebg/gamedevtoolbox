using System.Collections;
using UnityEngine;

namespace OriOpaStudio.AudioSystem
{
	public class AudioSystem : MonoBehaviour
	{
		private static IAudioPlayer audioPlayer;

		private void Awake()
		{
			//TODO: Dependency injection
			audioPlayer = new AudioPlayer();
		}

		public static void Play(AudioAsset audioAsset)
		{
			audioPlayer.Play(audioAsset);
		}

		public static void PlayDelayed(AudioAsset audioAsset, float seconds)
		{
			FindObjectOfType<MonoBehaviour>().StartCoroutine(PlayDelayedCoroutine(audioAsset, seconds));
		}

		private static IEnumerator PlayDelayedCoroutine(AudioAsset audioAsset, float seconds)
		{
			yield return new WaitForSeconds(seconds);
			audioPlayer.Play(audioAsset);
		}

		public static void Stop(AudioAsset audioAsset)
		{
			audioPlayer.StopAudio(audioAsset);
		}
	}
}