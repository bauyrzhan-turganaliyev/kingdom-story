using System.Collections.Generic;
using oks.Shop;
using UnityEngine;

namespace oks.GameResources
{
    public class Resource : ScriptableObject
    {
        public Type Type;
        public List<ShopSelectorType> ShopSelectorTypes;
        public int AveragePrice;
    }
}