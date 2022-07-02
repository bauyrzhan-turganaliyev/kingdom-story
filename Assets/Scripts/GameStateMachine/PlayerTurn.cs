using System.Collections;

namespace oks.GameStateMachine
{
    public class PlayerTurn : State
    {
        public PlayerTurn(GameSystem gameSystem) : base(gameSystem)
        {
        }

        public override IEnumerator Start()
        {
            GameSystem.SetText("Player turn...");
            
            yield break;
        }
    }
}