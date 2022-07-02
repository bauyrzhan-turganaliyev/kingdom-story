using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace oks.BattleSystem
{
    public class BattleTime : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _battlePanel;
        [SerializeField] private GameObject _aliasGameObject;
        [SerializeField] private GameObject _enemyGameObject;
        
        [SerializeField] private Transform _aliasParent;
        [SerializeField] private Transform _enemiesParent;
        
        private List<Battler> _currentAlias = new List<Battler>();
        private List<Battler> _currentEnemies = new List<Battler>();
        
        private List<Battler> _alias;
        private List<Battler> _enemies;
        private CreateBattler _createBattler;
        private oks.GameStateMachine.BattleSystem _battleSystem;

        public void Init(oks.GameStateMachine.BattleSystem battleSystem)
        {
            _battleSystem = battleSystem;
        }
        public void PrepairBattle(List<Battler> alias, List<Battler> enemies, CreateBattler createBattler)
        {
            _createBattler = createBattler;
            _enemies = enemies;
            _alias = alias;
            
            _battlePanel.SetActive(true);
            _transform.SetAsLastSibling();

            for (int i = 0; i < _alias.Count; i++)
            {
                var battlerObject = _createBattler.CreateBattlerObject(_alias[i]);
                battlerObject.Item1.transform.SetParent(_aliasParent);
                battlerObject.Item1.transform.localScale = new Vector3(1, 1, 1);
                _currentAlias.Add(battlerObject.Item2);
                _currentAlias[i].PrepareForBattle();
                _currentAlias[i].OnAttack += ProcessDamage;
            }
            for (int i = 0; i < _enemies.Count; i++)
            {
                var battlerObject = _createBattler.CreateBattlerObject(_enemies[i]);
                battlerObject.Item1.transform.SetParent(_enemiesParent);
                battlerObject.Item1.transform.localScale = new Vector3(1, 1, 1);
                
                _currentEnemies.Add(battlerObject.Item2);
                _currentEnemies[i].PrepareForBattle();
                _currentEnemies[i].OnAttack += ProcessDamage;
            }
            
            
        }

        private void ProcessDamage(Battler battler)
        {
            switch (battler.Team)
            {
                case Team.Alias:
                    if (_currentEnemies.Count == 0)
                    {
                        StopAllAlias();
                        return;
                    }
                    var randIntEnemy = Random.Range(0, _currentEnemies.Count);

                    if (_currentEnemies[randIntEnemy].DamageTaked(battler.Damage))
                    {
                        _currentEnemies.RemoveAt(randIntEnemy);
                    }
                    
                    break;
                case Team.Enemy:
                    if (_currentAlias.Count == 0)
                    {
                        StopAllEnemies();
                        return;
                    }
                    var randIntAlias = Random.Range(0, _currentAlias.Count);

                    if (_currentAlias[randIntAlias].DamageTaked(battler.Damage))
                    {
                        _currentAlias.RemoveAt(randIntAlias);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void StopAllEnemies()
        {
            for (int i = 0; i < _currentEnemies.Count; i++)
            {
                _currentEnemies[i].StopBattle();
            }
            
            _battleSystem.OnFinishedBattleAction?.Invoke(false);
        }

        private void StopAllAlias()
        {
            for (int i = 0; i < _currentAlias.Count; i++)
            {
                _currentAlias[i].StopBattle();
            }
            
            _battleSystem.OnFinishedBattleAction?.Invoke(true);
        }

        public void OnExit()
        {
            _battlePanel.SetActive(false);
            _battleSystem.OnQuitBattle?.Invoke();
        }
    }
}