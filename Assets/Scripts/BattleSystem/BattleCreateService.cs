using System.Collections;
using System.Collections.Generic;
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

        public void Init(BattleService battleService)
        {
            battleService.OnServiceOpened += ServiceOpened;
            battleService.OnServiceExit += ServiceExit;
            _createBattlerPanel.SetActive(false);
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
                    print("Alias Selected");
                    break;
                
                case (int)Team.Enemy:
                    team = Team.Enemy;
                    print("Enemy Selected");
                    break;
            }
            switch (_weaponSelect.value)
            {
                case (int) Weapons.Longsword:
                    weapon = Weapons.Longsword;
                    break;
                case (int) Weapons.Bow:
                    weapon = Weapons.Bow;
                    break;
                case (int) Weapons.SwordAndShield:
                    weapon = Weapons.SwordAndShield;
                    break;
                case (int) Weapons.Axe:
                    weapon = Weapons.Axe;
                    break;
                case (int) Weapons.NoWeapon:
                    weapon = Weapons.NoWeapon;
                    break;
                case (int) Weapons.Mace:
                    weapon = Weapons.Mace;
                    break;
            }

            if (float.TryParse(_damageIF.text, out float damageValue))
            {
                damage = damageValue;
            }
            if (float.TryParse(_damageCDIF.text, out float damageCDValue))
            {
                damageCD = damageCDValue;
            }

            for (int i = 0; i < _alias.Count; i++)
            {
                if (_alias[i].IsPlayer && _isPlayerToggle.isOn)
                {
                    _errorText.text = "Главный игрок уже существует!";
                    StartCoroutine(ShowError(_errorText));
                    return;
                }
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