using UnityEngine;
using OriOpaStudio.Utilities;

namespace OriOpaStudio.TurnSystem
{
    public class TurnSystemPlayer : MonoBehaviour
    {
        [SerializeField] private TurnPhase[] _phases;

        public delegate void EndTurn();
        public EndTurn OnEndTurn;

        private TurnSystem _turnSystem;
        private TurnPhase _currentPhase;
        private CircularList<TurnPhase> _turnPhases;

        private void Awake()
        {
            _turnSystem = FindObjectOfType<TurnSystem>();
            _turnPhases = new CircularList<TurnPhase>(_phases);
            _currentPhase = _turnPhases.First;
        }

        public void StartTurn()
        { 
            _currentPhase.StartPhase();
        }
        
        public void ChangeTurnPhase()
        {
            _currentPhase = _turnPhases.Next;

            if (_turnPhases.IsAtBeginning)
            {
                _turnSystem.CallNextTurn();
                return;
            }

            _currentPhase.StartPhase();
        }
    }
}