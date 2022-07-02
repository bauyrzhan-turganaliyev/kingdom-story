using System.Collections;
using UnityEngine;

namespace oks.GameStateMachine
{
    public class Begin : State
    {
        public Begin(GameSystem gameSystem) : base(gameSystem)
        {
        }
        public override IEnumerator Start()
        {
            GameSystem.SetText("Game starting...");
            
            yield return new WaitForSeconds(1f);
            
            GameSystem.SetState(new FreeTurn(GameSystem));
        }
    }
}