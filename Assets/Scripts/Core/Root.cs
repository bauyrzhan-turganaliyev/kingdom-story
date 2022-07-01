using turganaliyev.BattleSystem;
using turganaliyev.Jobs.Blacksmith;
using UnityEngine;

namespace turganaliyev.Core
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private BlacksmithService _blacksmithService;
        [SerializeField] private BattleService _battleService;
        private void Start()
        {
            _blacksmithService.Init();
            _battleService.Init();
        }
    }
}
