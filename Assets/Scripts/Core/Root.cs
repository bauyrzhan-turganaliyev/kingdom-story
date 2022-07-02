using oks.BattleSystem;
using oks.GameStateMachine;
using oks.Jobs.Blacksmith;
using UnityEngine;

namespace oks.Core
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private BlacksmithService _blacksmithService;
        [SerializeField] private BattleService _battleService;
        [SerializeField] private GameSystem _gameSystem;
        private void Start()
        {
            _gameSystem.Init();
            _blacksmithService.Init();
            _battleService.Init(_gameSystem.BattleSystem);
        }
    }
}
