using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace turganaliyev.BattleSystem
{
    public class Battler : MonoBehaviour
    {
        public TMP_Text DamageText;
        public TMP_Text DamageCDText;
        public Image WeaponImage;
        public TMP_Text PlayerOrNpcText;

        public Team Team;
        public Weapons Weapon;

        public float Damage;
        public float DamageReload;

        public bool IsPlayer;

        public Battler(Team team, Weapons weapon, float damage, float damageReload, bool isPlayer)
        {
            Team = team;
            Weapon = weapon;
            Damage = damage;
            DamageReload = damageReload;

            IsPlayer = isPlayer;
        }
    }
}