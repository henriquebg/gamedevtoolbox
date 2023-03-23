using UnityEngine;

namespace OriOpaStudio.AudioSystem
{
	public interface IAudioPlayer
	{
		public void Play(AudioAsset audioAsset);
		public void StopAudio(AudioAsset audioAsset);
	}
}