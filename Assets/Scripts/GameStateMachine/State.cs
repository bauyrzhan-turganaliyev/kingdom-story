using System.Collections;

namespace oks.GameStateMachine
{
    public abstract class State
    {
        protected GameSystem GameSystem;

        public State(GameSystem gameSystem)
        {
            GameSystem = gameSystem;
        }

        public virtual IEnumerator Start()
        {
            yield break;
        }
    }
}