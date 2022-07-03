using UnityEngine;

namespace oks.GameResources
{
    [CreateAssetMenu(fileName = "Armor", menuName = "ScriptableObjects/Armor", order = 1)]
    public class Armor : Resource
    {
        public float Defence;
        public int HealthPoint;
    }
}