using UnityEngine;

namespace oks.GameResources
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
    public class Weapon : Resource
    {
        public float DamageValue;
        public float DamageCooldown;
        public int HealthPoint;
    }
}