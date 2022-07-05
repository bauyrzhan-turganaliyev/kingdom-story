using System.Collections.Generic;
using oks.GameResources;
using UnityEngine;

namespace oks.PlayerData
{
    public class Player : MonoBehaviour
    {
        public int Money;
        public List<Resource> Resources;
        public Transform PlayerParentInShop;
        public bool CheckForTrade(int value)
        {
            if (value > Money) return false;

            return true;
        }

        public void AddItems(List<Resource> newResources)
        {
            for (int i = 0; i < newResources.Count; i++)
            {
                newResources[i].IsInPlayer = true;
                Resources.Add(newResources[i]);
            }
        }
        public List<Resource> GetItems(List<Resource> resources)
        {
            var resourcesToReturn = new List<Resource>();
            for (int i = 0; i < resources.Count; i++)
            {
                if (Resources.Contains(resources[i]))
                {
                    resourcesToReturn.Add(resources[i]);
                }
            }
            return resourcesToReturn;
        }
    }
}