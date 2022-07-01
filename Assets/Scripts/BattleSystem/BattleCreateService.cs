using System.Collections.Generic;
using UnityEngine;

namespace turganaliyev.BattleSystem
{
    public class BattleCreateService : MonoBehaviour
    {
        [SerializeField] private List<Battler> _alias = new List<Battler>();
        [SerializeField] private List<Battler> _enemies = new List<Battler>();

        [SerializeField] private GameObject _createBattlerPanel;

        public void Init()
        {
            _createBattlerPanel.SetActive(false);
        }
        
        
    }
}