using System.Collections;

namespace oks.GameStateMachine
{
    public class EnemyTurn : State
    {
        public EnemyTurn(GameSystem gameSystem) : base(gameSystem)
        {
        }

        public override IEnumerator Start()
        {
            GameSystem.SetText("Enemy turn...");   
            yield break;
        }
    }
}