using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OriOpaStudio.ActionSystem
{
    [System.Serializable]
    public class Sequencer : MonoBehaviour
    {
        [SerializeField] private List<Keyframe> timeline;

        public List<Keyframe> Timeline { get; }

        public void PlaySequence()
        {
            for(int keyframe = 0; keyframe < timeline.Count; keyframe++)
            {
                StartCoroutine(Play(keyframe));
            }
        }

        private IEnumerator Play(int keyframeIndex)
        {
            yield return new WaitForSeconds(timeline[keyframeIndex].StartTime);
            timeline[keyframeIndex].Event.Play();
        }
    }
}