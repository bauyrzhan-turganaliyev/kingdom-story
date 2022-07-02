using System;

namespace oks.GameStateMachine
{
    public class BattleSystem : GameSystem
    {
        public Action OnBeginBattleAction;
        public Action<bool> OnFinishedBattleAction;
        public Action OnQuitBattle;
    }
}