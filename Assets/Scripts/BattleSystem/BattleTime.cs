using System.Collections.Generic;
using UnityEngine;

namespace turganaliyev.BattleSystem
{
    public class BattleTime : MonoBehaviour
    {
        [SerializeField] private GameObject _battlePanel;
        private List<Battler> _alias;
        private List<Battler> _enemies;

        public void PrepairBattle(List<Battler> alias, List<Battler> enemies)
        {
            _enemies = enemies;
            _alias = alias;
            
            _battlePanel.SetActive(true);
        }
    }
}