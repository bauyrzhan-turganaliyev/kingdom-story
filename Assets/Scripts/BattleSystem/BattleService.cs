using UnityEngine;

namespace turganaliyev.BattleSystem
{
    public class BattleService : MonoBehaviour
    {
        [SerializeField] private BattleCreateService _battleCreateService;
        [SerializeField] private GameObject _battleSetupPanel;

        public void Init()
        {
            _battleCreateService.Init();
            _battleSetupPanel.SetActive(false);
        }

        public void OnClick()
        {
            _battleSetupPanel.SetActive(true);
        }
    }
}