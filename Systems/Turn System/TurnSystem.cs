using UnityEngine;
using OriOpaStudio.Utilities;

namespace OriOpaStudio.TurnSystem
{
    public class TurnSystem : MonoBehaviour
    {
        private static TurnSystem _instance;

        [SerializeField] private TurnSystemPlayer[] _playersInGame;

        private TurnSystemPlayer _currentPlayer;
        private CircularList<TurnSystemPlayer> _players;
        private bool _isStarted = false;
        
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                return;
            }

            Destroy(gameObject);
        }


        void Start()
        {
            _players = new CircularList<TurnSystemPlayer>(_playersInGame);
            _currentPlayer = _players.First;
        }

        public void StartGame()
        {
            if (!_isStarted)
            {
                _currentPlayer.StartTurn();
                _isStarted = true;
            }
        }

        public void CallNextTurn()
        {
            _currentPlayer = _players.Next;
            _currentPlayer.StartTurn();
        }

        public void CallNextPhase()
        {
            _currentPlayer.ChangeTurnPhase();
        }
    }
}