using System.Collections;

namespace oks.GameStateMachine
{
    internal class AliasWin : State
    {
        public AliasWin(GameSystem gameSystem) : base(gameSystem)
        {
        }

        public override IEnumerator Start()
        {
            GameSystem.SetText(" We win...");
            yield break;
        }
    }
}