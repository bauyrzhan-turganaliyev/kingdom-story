using System.Collections;

namespace oks.GameStateMachine
{
    internal class EnemiesWin : State
    {
        public EnemiesWin(GameSystem gameSystem) : base(gameSystem)
        {
        }

        public override IEnumerator Start()
        {
            
            GameSystem.SetText(" We lose...");
            yield break;
        }
    }
}