using TMPro;
using UnityEngine;

namespace oks.GameStateMachine
{
    public class GameSystem : StateMachine
    {
        public BattleSystem BattleSystem;
        [SerializeField] private TMP_Text _stateText;

        public void Init()
        {
            SubscribeServices();
            SetState(new Begin(this));
        }

        private void SubscribeServices()
        {
            BattleSystem.OnBeginBattleAction += OnBeginBattle;
            BattleSystem.OnFinishedBattleAction += OnFinishedBattle;
            BattleSystem.OnQuitBattle += OnQuitBattle;
        }

        private void OnFinishedBattle(bool flag)
        {
            if (flag)
            {
                SetState(new AliasWin(this));
            }
            else
            {
                SetState(new EnemiesWin(this));
            }
        }

        public void SetText(string message)
        {
            _stateText.text = "Game state: " + message;
        }

        private void OnBeginBattle()
        {
            SetState(new BattleBeginning(this));
        }

        private void OnQuitBattle()
        {
            SetState(new FreeTurn(this));
        }
    }
}