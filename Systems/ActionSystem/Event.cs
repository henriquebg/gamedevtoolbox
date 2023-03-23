using UnityEngine;

namespace OriOpaStudio.ActionSystem
{
    public class Event : MonoBehaviour
    {        
        [SerializeField] private GameObject owner;
        [SerializeField] private Action[] actions;
        [SerializeField, HideInInspector] private string eventName = "New Event";

        public string OwnerName { get { return owner.name; } }
        public string EventName { get { return eventName; } set { eventName = value; } }

        public void Play()
        {
            foreach (var action in actions)
            {
                action.Play();
            }
        }
    }
}