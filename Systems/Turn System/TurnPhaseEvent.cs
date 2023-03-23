using UnityEngine;
using UnityEngine.Events;

namespace OriOpaStudio.TurnSystem
{
    public class TurnPhaseEvent : MonoBehaviour
    {
        [SerializeField] private TurnPhase _turnPhase;
        [SerializeField] private UnityEvent _unityEvent;

        private void Awake() => _turnPhase.Register(gameEventListener: this);
        private void OnDestroy() => _turnPhase.Deregister(gameEventListener: this);
        private void OnDisable() => _turnPhase.Deregister(gameEventListener: this);

        public void RaiseEvent() => _unityEvent.Invoke();
    }
}