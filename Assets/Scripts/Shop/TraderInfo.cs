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
        [SerializeField] private ResourceInfo _resourcePrefab;

        [SerializeField] private List<Resource> _resourcesForBuy;
        [SerializeField] private List<Resource> _resourcesForSell;
        
        private List<Resource> _resourcesFromPlayer = new List<Resource>();
        
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
            UpdatePlayerInventory();

            for (int i = 0; i < _resourceList.Count; i++)
            {
                var item = Instantiate(_resourcePrefab, _traderParent);
                item.Init(_resourceList[i]);
                item.ResourceClicked += OnClickToResource;
            }
        }

        public void OnClickToTrade()
        {

            if (_totalCost >= _totalIncome)
            {
                if (!_gameResourcesHub.Player.CheckForTrade(_totalCost))
                {
                    _errorText.text = "У вас не хватает монет!";
                    StartCoroutine(ShowError(_errorText));
                    return;
                }

                _gameResourcesHub.Player.AddItems(_resourcesForBuy);
            }
            else
            {
                _resourcesFromPlayer = _gameResourcesHub.Player.GetItems(_resourcesForSell);
            }

            UpdateTraderInventory();
            UpdatePlayerInventory();
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
            ClearTraderPanel();
            
            for (int i = 0; i < _resourcesForBuy.Count; i++)
            {
                if (_resourceList.Contains(_resourcesForBuy[i]))
                {
                    var index = _resourceList.IndexOf(_resourcesForBuy[i]);
                    
                    _resourceList.RemoveAt(index);
                    _resourcesForBuy.RemoveAt(i);
                    
                }
            }
            print(_resourceList.Count);

            for (int i = 0; i < _resourcesFromPlayer.Count; i++)
            {
                _resourceList.Add(_resourcesFromPlayer[i]);
            }
            
            for (int i = 0; i < _resourceList.Count; i++)
            {
                var item = Instantiate(_resourcePrefab, _traderParent);
                item.Init(_resourceList[i]);
                item.ResourceClicked += OnClickToResource;
            }
            
        }

        private void UpdatePlayerInventory()
        {
            ClearPlayerPanel();
            
            for (int i = 0; i < _gameResourcesHub.Player.Resources.Count; i++)
            {
                var item = Instantiate(_resourcePrefab, _playerParent);
                item.Init(_gameResourcesHub.Player.Resources[i]);
                item.ResourceClicked += OnClickToResource;
            }
        }

        private void OnClickToResource(Resource resource, bool flag)
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

        private void AddResource(Resource resource)
        {
            if (resource.IsInPlayer)
            {
                _resourcesForSell.Add(resource);
                _totalIncome += resource.AveragePrice;
            }
            else
            {
                print("Adding resource...");
                _resourcesForBuy.Add(resource);
                _totalCost += resource.AveragePrice;
            }
            
            _buySellText.text = $"Продажа/покупка:  {_totalIncome}/{_totalCost}";
            _totalCostText.text = $"Ты заплатишь: {_totalCost}";
        }

        private void RemoveResource(Resource resource)
        {
            if (_resourcesForSell.Contains(resource))
            {
                var index = _resourcesForSell.IndexOf(resource);
                _resourcesForSell.RemoveAt(index);
                _totalIncome -= resource.AveragePrice;
            }

            if (_resourcesForBuy.Contains(resource))
            {
                var index = _resourcesForBuy.IndexOf(resource);
                _resourcesForBuy.RemoveAt(index);
                _totalCost -= resource.AveragePrice;
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