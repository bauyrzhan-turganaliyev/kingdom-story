using System.Collections;

namespace oks.GameStateMachine
{
    public class FreeTurn : State
    {
        public FreeTurn(GameSystem gameSystem) : base(gameSystem)
        {
        }

        public override IEnumerator Start()
        {
            GameSystem.SetText("Free turn...");
            
            yield break;
            
        }
    }
}