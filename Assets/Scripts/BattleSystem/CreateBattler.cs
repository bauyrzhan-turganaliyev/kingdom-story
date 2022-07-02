using System.Collections.Generic;
using TMPro;
using turganaliyev.Jobs.Blacksmith;
using UnityEngine;
using UnityEngine.UI;

namespace turganaliyev.BattleSystem
{
    public class CreateBattler : MonoBehaviour
    {
        [SerializeField] private GameObject _battlerAliasObject;
        [SerializeField] private GameObject _battlerEnemyObject;
        [SerializeField] private List<Sprite> _weaponsList;
        
        public GameObject CreateBattlerObject(Battler battler)
        {
            GameObject battlerObject = null;
            battlerObject = Instantiate(battler.Team == Team.Alias ? _battlerAliasObject : _battlerEnemyObject);

            var battlerComponent = battlerObject.GetComponent<Battler>();

            battlerComponent.Damage = battler.Damage;
            battlerComponent.DamageReload = battler.DamageReload;
            battlerComponent.Team = battler.Team;
            battlerComponent.Weapon = battler.Weapon;
            battlerComponent.IsPlayer = battler.IsPlayer;

            battlerComponent.DamageText.text = battlerComponent.Damage.ToString();
            battlerComponent.DamageCDText.text = battlerComponent.DamageReload.ToString();

            battlerComponent.PlayerOrNpcText.text = battlerComponent.IsPlayer ? "Player" : "NPC";
            battlerComponent.PlayerOrNpcText.color = battlerComponent.IsPlayer ? Color.green : Color.red;
            var weaponImage = battlerComponent.WeaponImage;
            switch ((int)battlerComponent.Weapon)
            {
                case (int) Weapons.Longsword:
                    weaponImage.sprite = _weaponsList[0];
                    break;
                case (int) Weapons.Bow:
                    weaponImage.sprite = _weaponsList[1];
                    break;
                case (int) Weapons.SwordAndShield:
                    weaponImage.sprite = _weaponsList[2];
                    break;
                case (int) Weapons.Axe:
                    weaponImage.sprite = _weaponsList[3];
                    break;
                case (int) Weapons.Mace:
                    weaponImage.sprite = _weaponsList[4];
                    break;
                case (int) Weapons.NoWeapon:
                    weaponImage.sprite = _weaponsList[5];
                    break;
            }

            return battlerObject;
        }
    }
}