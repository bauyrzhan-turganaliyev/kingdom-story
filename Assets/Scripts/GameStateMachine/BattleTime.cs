using System.Collections;

namespace oks.GameStateMachine
{
    public class BattleTime : State
    {
        public BattleTime(GameSystem gameSystem) : base(gameSystem)
        {
        }

        public override IEnumerator Start()
        {
            GameSystem.SetText("Battle time...");
            yield break;
        }
    }
}