using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace OriOpaStudio.AudioSystem
{
	public class AudioPlayer : IAudioPlayer
	{
		private CompomentPool<AudioSource> pool;
		private HashSet<AudioSource> inUse;

		public AudioPlayer()
		{
			pool = new CompomentPool<AudioSource>();
			inUse = new HashSet<AudioSource>();
		}

		public void Play(AudioAsset audioAsset)
		{
			var audioSource = pool.GetNextAvailable();
			audioSource.clip = audioAsset.Clip;
			audioSource.volume = audioAsset.Volume;
			audioSource.pitch = audioAsset.Pitch;
			audioSource.loop = audioAsset.Loop;
			audioSource.Play();
			inUse.Add(audioSource);
		}

		public void StopAudio(AudioAsset audioAsset)
		{
			var audioSources = inUse.Where<AudioSource>(audioSource => audioSource.clip == audioAsset.Clip);

			foreach (var audioSource in audioSources)
			{
				audioSource.Stop();
			}

			pool.ClearPool();
			ClearUnusedAudioSources();
		}

		private void ClearUnusedAudioSources()
		{
			var audioSources = inUse.Where<AudioSource>(audioSource => audioSource.isPlaying);

			inUse.RemoveWhere(audioSource => audioSources.Contains(audioSource));
		}
	}
}