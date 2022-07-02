using oks.GameStateMachine;
using turganaliyev.BattleSystem;
using turganaliyev.Jobs.Blacksmith;
using UnityEngine;

namespace turganaliyev.Core
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
            _battleService.Init();
        }
    }
}
