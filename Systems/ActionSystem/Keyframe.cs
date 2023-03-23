using System;
using UnityEngine;

namespace OriOpaStudio.ActionSystem
{
    [Serializable]
    public class Keyframe
    {
        [SerializeField] private Event keyframeEvent;
        [SerializeField] private float startTime;

        public Event Event { get { return keyframeEvent; } }
        public float StartTime { get { return startTime; } }

        public Keyframe(Event keyframeEvent)
        {
            this.keyframeEvent = keyframeEvent;
        }
    }
}