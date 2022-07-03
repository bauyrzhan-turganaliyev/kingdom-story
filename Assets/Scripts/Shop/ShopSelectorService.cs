using System;
using System.Collections.Generic;
using oks.Core;
using UnityEngine;

namespace oks.Shop
{
    public class ShopSelectorService : MonoBehaviour
    {
        [SerializeField] private List<ShopSelector> _shopSelectors;
        private TradeService _tradeService;

        public Action OnClickedTrader;

        public void Init(TradeService tradeService, GameResourcesHUB gameResourcesHub)
        {
            _tradeService = tradeService;
            _tradeService.Init(gameResourcesHub);   
            foreach (var shopSelector in _shopSelectors)
            {
                shopSelector.OnClicked += OnClickedShoper;
            }
        }

        private void OnClickedShoper(ShopSelector shopSelector)
        {
            _tradeService.StartTrading(shopSelector.Type);
            
            OnClickedTrader?.Invoke();
        }
    }

    public enum ShopSelectorType
    {
        Armorer,
        Gunsmith,
        Butcher,
        Trader,
        Alchemist
    }
}