using System;
using System.Collections.Generic;
using UnityEngine;

namespace oks.GameResources
{
    [CreateAssetMenu(fileName = "ResourcesData", menuName = "ScriptableObjects/ResourcesData", order = 1)]
    public class GameResourceService : ScriptableObject
    {
        public List<Resource> Resources = new List<Resource>();
    }
    [System.Serializable]
    public enum Type {
        Weapon,
        Armor,
        Food,
        Mineral,
        Default
    }
}