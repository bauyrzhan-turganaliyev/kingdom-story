using System;
using System.Collections.Generic;
using oks.Core;
using oks.GameResources;
using UnityEngine;

namespace oks.Shop
{
    public class TradeService : MonoBehaviour
    {
        [SerializeField] private TraderInfo _traderInfo;
        [SerializeField] private GameObject _tradingPanel;
        [SerializeField] private Transform _traderParent;

        [SerializeField] private List<Resource> _armorerAvailableItems;
        [SerializeField] private List<Resource> _gunsmithAvailableItems;
        [SerializeField] private List<Resource> _butcherAvailableItems;
        [SerializeField] private List<Resource> _traderAvailableItems;
        [SerializeField] private List<Resource> _alchemistAvailableItems;
        
        private GameResourcesHUB _gameResourcesHub;
        public void Init(GameResourcesHUB gameResourcesHub)
        {
            _gameResourcesHub = gameResourcesHub;
            
            SortAllItems();
        }
        public void StartTrading(ShopSelectorType shopSelectorType)
        {
            _tradingPanel.SetActive(true);
            switch (shopSelectorType)
            {
                case ShopSelectorType.Armorer:
                    StartTradingArmorer();
                    break;
                case ShopSelectorType.Butcher:
                    StartTradingButcher();
                    break;
                case ShopSelectorType.Alchemist:
                    StartTradingAlchemist();
                    break;
                case ShopSelectorType.Gunsmith:
                    StartTradingGunsmith();
                    break;
                case ShopSelectorType.Trader:
                    StartTradingTrader();
                    break;
            }
        }

        private void StartTradingTrader()
        {
            _traderInfo.Init(_traderAvailableItems, _traderParent, _gameResourcesHub);
        }

        private void StartTradingGunsmith()
        {
            _traderInfo.Init(_gunsmithAvailableItems, _traderParent, _gameResourcesHub);
        }

        private void StartTradingAlchemist()
        {
            _traderInfo.Init(_alchemistAvailableItems, _traderParent, _gameResourcesHub);
        }

        private void StartTradingButcher()
        {
            _traderInfo.Init(_butcherAvailableItems, _traderParent, _gameResourcesHub);
        }

        private void StartTradingArmorer()
        {
            _traderInfo.Init(_armorerAvailableItems, _traderParent, _gameResourcesHub);
        }
        
        private void SortAllItems()
        {
            foreach (var resource in _gameResourcesHub.GameResourceService.Resources)
            {
                foreach (var resourceType in resource.ShopSelectorTypes)
                {
                    switch (resourceType)
                    {
                        case ShopSelectorType.Alchemist:
                            _alchemistAvailableItems.Add(resource);
                            break;
                        case ShopSelectorType.Armorer:
                            _armorerAvailableItems.Add(resource);
                            break;
                        case ShopSelectorType.Butcher:
                            _butcherAvailableItems.Add(resource);
                            break;
                        case ShopSelectorType.Gunsmith:
                            _gunsmithAvailableItems.Add(resource);
                            break;
                        case ShopSelectorType.Trader:
                            _traderAvailableItems.Add(resource);
                            break;
                    }
                }
            }
        }

        public void OnClickExit()
        {
            
            _tradingPanel.SetActive(false);
        }
    }
}