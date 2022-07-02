using System.Collections;
using UnityEngine;

namespace oks.GameStateMachine
{
    public class BattleBeginning : State
    {
        public BattleBeginning(GameSystem gameSystem) : base(gameSystem)
        {
        }

        public override IEnumerator Start()
        {
            GameSystem.SetText("Battle starting...");
            
            yield break;
        }
    }
}