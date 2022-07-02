using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace oks.BattleSystem
{
    [System.Serializable]
    public class Battler : MonoBehaviour
    {
        public TMP_Text DamageText;
        public TMP_Text DamageCDText;
        public Slider HPBar;
        public Image WeaponImage;
        public TMP_Text PlayerOrNpcText;


        public Team Team;
        public Weapons Weapon;

        public float Damage;
        public float DamageReload;
        public float HP;

        public bool IsPlayer;

        public Action<Battler> OnAttack;
        
        private float nextUpdate;
        private bool _isBattleTime;
        public Battler(Team team, Weapons weapon, float damage, float damageReload, bool isPlayer)
        {
            Team = team;
            Weapon = weapon;
            Damage = damage;
            DamageReload = damageReload;
            HP = 100;

            IsPlayer = isPlayer;

            nextUpdate = damageReload;
        }

        public void PrepareForBattle()
        {
            _isBattleTime = true;
        }

        public void StopBattle()
        {
            _isBattleTime = false;
        }

        public bool DamageTaked(float damageValue)
        {
            HP -= damageValue;
            HPBar.value = HP;
            if (HP <= 0)
            {
                _isBattleTime = false;
                return true;
            }
            return false;
        }

        private void Update()
        {
            if (Time.time >= nextUpdate && _isBattleTime)
            {
                nextUpdate = Time.time + DamageReload;
                UpdateEveryTime();
            }
        }

        private void UpdateEveryTime()
        {
            print(name + " is Attacking!!!");
            OnAttack?.Invoke(this);
        }
    }
}