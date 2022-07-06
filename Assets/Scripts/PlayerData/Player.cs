using System.Collections.Generic;
using oks.GameResources;
using TMPro;
using UnityEngine;

namespace oks.PlayerData
{
    public class Player : MonoBehaviour
    {
        public int Money;

        public TMP_Text ShopMoneyText; 
        public List<ResourceInfo> Resources;
        public Transform PlayerParentInShop;
        public bool CheckForTrade(int value)
        {
            if (value > Money) return false;

            SubMoney(value);
            return true;
        }
        public void AddMoney(int value)
        {
            print($"{value} money for add");
            
            Money -= value;
            ShopMoneyText.text = "Твое состояние: " + Money;
        }
        public void AddItems(ref List<ResourceInfo> newResources)
        {
            for (int i = 0; i < newResources.Count; i++)
            {
                newResources[i].TransferToPlayer();
                Resources.Add(newResources[i]);
            }
        }
        public List<ResourceInfo> GetItems(List<ResourceInfo> resources)
        {
            var resourcesToReturn = new List<ResourceInfo>();
            for (int i = 0; i < resources.Count; i++)
            {
                if (Resources.Contains(resources[i]))
                {
                    resources[i].IsInPlayer = false;
                    resourcesToReturn.Add(resources[i]);
                    Resources.Remove(resources[i]);
                }
            }
            return resourcesToReturn;
        }

        private void SubMoney(int value)
        {
            Money -= value;
            ShopMoneyText.text = "Твое состояние: " + Money;
        }
    }
}