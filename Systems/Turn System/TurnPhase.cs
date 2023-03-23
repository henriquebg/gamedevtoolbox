using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OriOpaStudio.TurnSystem
{
    [CreateAssetMenu(fileName = "New Turn Phase", menuName = "Game Dev Toolbox/Turn System/TurnPhase")]
    public class TurnPhase : ScriptableObject
    {
        HashSet<TurnPhaseEvent> _listeners = new HashSet<TurnPhaseEvent>();

        public void StartPhase()
        {
            foreach (var globalEventListener in _listeners.ToList())
                globalEventListener.RaiseEvent();
        }

        public void Register(TurnPhaseEvent gameEventListener) => _listeners.Add(gameEventListener);
        public void Deregister(TurnPhaseEvent gameEventListener) => _listeners.Remove(gameEventListener);
    }
}