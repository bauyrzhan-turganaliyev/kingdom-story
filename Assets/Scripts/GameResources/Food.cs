using UnityEngine;

namespace oks.GameResources
{
    [CreateAssetMenu(fileName = "Food", menuName = "ScriptableObjects/Food", order = 1)]
    public class Food : Resource
    {
        public float HPRestore;
    }
}