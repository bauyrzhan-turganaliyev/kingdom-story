using System.Collections;
using System.Collections.Generic;
using oks.Core;
using oks.GameResources;
using TMPro;
using UnityEngine;

namespace oks.Shop
{
    public class TraderInfo : MonoBehaviour
    {
        [SerializeField] private TMP_Text _buySellText;
        [SerializeField] private TMP_Text _totalCostText;
        [SerializeField] private TMP_Text _errorText;
        
        [SerializeField] private List<Resource> _resourceList;
        [SerializeField] private List<ResourceInfo> _traderInventory;
        [SerializeField] private ResourceInfo _resourcePrefab;

        [SerializeField] private List<ResourceInfo> _resourcesForBuy;
        [SerializeField] private List<ResourceInfo> _resourcesForSell;
        
        private List<ResourceInfo> _resourcesFromPlayer = new List<ResourceInfo>();
        
        private Transform _traderParent;
        private Transform _playerParent;
        
        private int _totalCost;
        private int _totalIncome;
        private GameResourcesHUB _gameResourcesHub;

        public void Init(List<Resource> resourceList, Transform parent, GameResourcesHUB gameResourcesHub)
        {
            _traderParent = parent;
            _resourceList = resourceList;
            _gameResourcesHub = gameResourcesHub;
            _playerParent = _gameResourcesHub.Player.PlayerParentInShop;

            ClearTraderPanel();

            for (int i = 0; i < _resourceList.Count; i++)
            {
                var item = Instantiate(_resourcePrefab, _traderParent);
                item.Init(_resourceList[i], false);
                item.ResourceClicked += OnClickToResource;
                _traderInventory.Add(item);
            }
        }

        public void OnClickToTrade()
        {
            print(_totalCost - _totalIncome);
            if (_totalCost - _totalIncome <= 0)
            {
                _gameResourcesHub.Player.AddMoney(_totalCost - _totalIncome);
            } else if (!_gameResourcesHub.Player.CheckForTrade(_totalCost - _totalIncome))
            {
                _errorText.text = "У вас не хватает монет!";
                StartCoroutine(ShowError(_errorText));
                return;
            }
            
            _gameResourcesHub.Player.AddItems(ref _resourcesForBuy);
            _resourcesFromPlayer = _gameResourcesHub.Player.GetItems(_resourcesForSell);
            
            
            UpdateTraderInventory();
            UpdateTexts();
        }

        private void UpdateTexts()
        {
            _totalCost = 0;
            _totalIncome = 0;
            _buySellText.text = $"Продажа/покупка:  {_totalIncome}/{_totalCost}";
            _totalCostText.text = $"Ты заплатишь: {_totalCost}";
        }

        private void UpdateTraderInventory()
        {
            for (int i = 0; i < _resourcesForBuy.Count; i++)
            {
                _resourcesForBuy[i].transform.parent = _gameResourcesHub.Player.PlayerParentInShop;
            }

            for (var i = 0; i < _resourcesForBuy.Count; i++)
            {
                if (_traderInventory.Remove(_resourcesForBuy[i]))
                {
                    _resourcesForBuy.RemoveAt(i);
                    i = -1;
                }
            }

            for (int i = 0; i < _resourcesFromPlayer.Count; i++)
            {
                _resourcesFromPlayer[i].transform.parent = _traderParent;
                _resourcesFromPlayer[i].OnDiselect();
                _traderInventory.Add(_resourcesFromPlayer[i]);  
            }

            _resourcesFromPlayer.Clear();
            _resourcesForSell.Clear();
        }
        private void OnClickToResource(ResourceInfo resource, bool flag)
        {
            if (flag)
            {
                AddResource(resource);
            }
            else
            {
                RemoveResource(resource);
            }
        }

        private void AddResource(ResourceInfo resource)
        {
            if (resource.IsInPlayer)
            {
                _resourcesForSell.Add(resource);
                _totalIncome += resource.Price;
            }
            else
            {
                print("Adding resource...");
                _resourcesForBuy.Add(resource);
                _totalCost += resource.Price;
            }
            
            _buySellText.text = $"Продажа/покупка:  {_totalIncome}/{_totalCost}";

            if (_totalCost - _totalIncome <= 0)
            {
                _totalCostText.text = $"Ты получишь: {(_totalCost - _totalIncome) * -1}";
            }
            else
            {
                _totalCostText.text = $"Ты заплатишь: {_totalCost - _totalIncome}";
            }
        }

        private void RemoveResource(ResourceInfo resource)
        {
            if (_resourcesForSell.Contains(resource))
            {
                var index = _resourcesForSell.IndexOf(resource);
                _resourcesForSell.RemoveAt(index);
                _totalIncome -= resource.Price;
            }

            if (_resourcesForBuy.Contains(resource))
            {
                var index = _resourcesForBuy.IndexOf(resource);
                _resourcesForBuy.RemoveAt(index);
                _totalCost -= resource.Price;
            }

            _buySellText.text = $"Продажа/покупка:  {_totalIncome}/{_totalCost}";
            _totalCostText.text = $"Ты заплатишь: {_totalCost}";
        }

        private void ClearTraderPanel()
        {
            for (int i = 0; i < _traderParent.childCount; i++)
            {
                Destroy(_traderParent.GetChild(i).gameObject);    
            }
            _traderInventory.Clear();
        }
        
        private void ClearPlayerPanel()
        {
            for (int i = 0; i < _playerParent.childCount; i++)
            {
                Destroy(_playerParent.GetChild(i).gameObject);    
            }
        }
        private IEnumerator ShowError(TMP_Text text)
        {
            text.enabled = true;
            yield return new WaitForSeconds(2);
            text.enabled = false;
        }
    }
}