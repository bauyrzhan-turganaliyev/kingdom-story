using System;

namespace oks.GameStateMachine
{
    public class BattleSystem : StateMachine
    {
        public Action OnBeginBattleAction;
        
        public void OnBeginBattle()
        {
            OnBeginBattleAction?.Invoke();
        }
    }
}