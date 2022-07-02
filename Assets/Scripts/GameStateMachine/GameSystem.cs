using TMPro;
using UnityEngine;

namespace oks.GameStateMachine
{
    public class GameSystem : StateMachine
    {
        [SerializeField] private BattleSystem _battleSystem;
        [SerializeField] private TMP_Text _stateText;

        public void Init()
        {
            SubscribeServices();
            SetState(new Begin(this));
        }

        private void SubscribeServices()
        {
            _battleSystem.OnBeginBattleAction += OnBeginBattle;
        }

        public void SetText(string message)
        {
            _stateText.text = "Game state: " + message;
        }

        private void OnBeginBattle()
        {
            SetState(new BattleBeginning(this));
        }
    }
}