using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace turganaliyev.BattleSystem
{
    public class BattleCreateService : MonoBehaviour
    {
        [SerializeField] private CreateBattler _createBattler;
        
        [SerializeField] private List<Battler> _alias = new List<Battler>();
        [SerializeField] private List<Battler> _enemies = new List<Battler>();

        [SerializeField] private GameObject _createBattlerPanel;

        [SerializeField] private TMP_Dropdown _teamSelect;
        [SerializeField] private TMP_Dropdown _weaponSelect;
        
        [SerializeField] private TMP_InputField _damageIF;
        [SerializeField] private TMP_InputField _damageCDIF;
        
        [SerializeField] private Toggle _isPlayerToggle;
        
        [SerializeField] private TMP_Text _errorText;

        [SerializeField] private Transform _aliasParent;
        [SerializeField] private Transform _enemiesParent;

        public Action<List<Battler>, List<Battler>> OnClickBeginBattle;
        private BattleService _battleService;

        public void Init(BattleService battleService)
        {
            _battleService = battleService;
            battleService.OnServiceOpened += ServiceOpened;
            battleService.OnServiceExit += ServiceExit;
            OnClickBeginBattle += battleService.OnClickBeginBattle;
            _createBattlerPanel.SetActive(false);
        }
        public void OnClickStartBattle()
        {
            _battleService.OnExit();
            OnClickBeginBattle?.Invoke(_alias, _enemies);
        }
        public void OnClickCreateBattler()
        {
            _createBattlerPanel.SetActive(true);
        }
        public void OnClickCancel()
        {
            _createBattlerPanel.SetActive(false);
        }
        public void OnClickAccept()
        {
            Team team = Team.Alias;
            Weapons weapon = Weapons.Longsword;
            float damage = 2;
            float damageCD = 2;

            var _isAlias = false;
            switch (_teamSelect.value)
            {
                case (int)Team.Alias:
                    team = Team.Alias;
                    _isAlias = true;
                    break;
                
                case (int)Team.Enemy:
                    team = Team.Enemy;
                    break;
            }

            weapon = _weaponSelect.value switch
            {
                (int)Weapons.Longsword => Weapons.Longsword,
                (int)Weapons.Bow => Weapons.Bow,
                (int)Weapons.SwordAndShield => Weapons.SwordAndShield,
                (int)Weapons.Axe => Weapons.Axe,
                (int)Weapons.NoWeapon => Weapons.NoWeapon,
                (int)Weapons.Mace => Weapons.Mace,
                _ => weapon
            };

            if (float.TryParse(_damageIF.text, out var damageValue))
            {
                damage = damageValue;
            }
            if (float.TryParse(_damageCDIF.text, out var damageCDValue))
            {
                damageCD = damageCDValue;
            }

            if (_alias.Any(t => t.IsPlayer && _isPlayerToggle.isOn))
            {
                _errorText.text = "Главный игрок уже существует!";
                StartCoroutine(ShowError(_errorText));
                return;
            }

            if (!_isAlias && _isPlayerToggle.isOn)
            {
                _errorText.text = "Главный игрок не может быть во вражейской команде!";
                StartCoroutine(ShowError(_errorText));
                return;
            }
            
            Battler battler = new Battler(team, weapon, damage, damageCD, _isPlayerToggle.isOn);

            var battlerObject = _createBattler.CreateBattlerObject(battler);            
            if (_isAlias)
            {
                _alias.Add(battler);
                battlerObject.transform.SetParent(_aliasParent);
            }
            else
            {
                _enemies.Add(battler);
                battlerObject.transform.SetParent(_enemiesParent);
            }

            battlerObject.transform.localScale = new Vector3(1, 1, 1);
        }
        private void ServiceOpened()
        {
            _createBattlerPanel.SetActive(false);
        }
        private void ServiceExit()
        {
            _createBattlerPanel.SetActive(false);
        }

        private IEnumerator ShowError(TMP_Text text)
        {
            text.enabled = true;
            yield return new WaitForSeconds(2);
            text.enabled = false;
        }

    }
}