using UnityEngine;
using Cinemachine;

namespace OriOpaStudio.Utilities
{
	public class CameraSwapper : MonoBehaviour
	{
		private CinemachineVirtualCamera fromCamera;

		private void Start()
		{
			fromCamera = FindObjectOfType<CinemachineBrain>().ActiveVirtualCamera as CinemachineVirtualCamera;
		}

		public void Swap(CinemachineVirtualCamera toCamera)
		{
			if (fromCamera != null)
				fromCamera.enabled = false;
			
			toCamera.enabled = true;
			fromCamera = toCamera;
		}
	}
}