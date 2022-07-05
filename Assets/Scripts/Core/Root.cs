using oks.BattleSystem;
using oks.GameResources;
using oks.GameStateMachine;
using oks.Jobs.Blacksmith;
using oks.PlayerData;
using oks.Shop;
using UnityEngine;

namespace oks.Core
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private BlacksmithService _blacksmithService;
        [SerializeField] private BattleService _battleService;
        [SerializeField] private GameSystem _gameSystem;
        [SerializeField] private ShopService _shopService;
        [SerializeField] private GameResourcesHUB _gameResourcesHub;
        private void Start()
        {
            _gameSystem.Init();
            _blacksmithService.Init();
            _battleService.Init(_gameSystem.BattleSystem);
            _shopService.Init(_gameResourcesHub);
        }
    }
}
