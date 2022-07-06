using System;
using System.Collections.Generic;
using oks.Core;
using UnityEngine;

namespace oks.Shop
{
    public class ShopService : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _shopPanel;
        [SerializeField] private ShopSelectorService _shopSelectorService;
        [SerializeField] private TradeService _tradeService;
        public void Init(GameResourcesHUB gameResourcesHub)
        {
            _shopSelectorService.Init(_tradeService, gameResourcesHub);
            _shopSelectorService.QuitFromTradeAction += QuitFromTrade;
            _shopSelectorService.OnClickedTrader += OnClickExit;
        }

        private void QuitFromTrade()
        {
            _shopPanel.SetActive(true);
            _transform.SetAsLastSibling();
        }

        public void OnClickEnter()
        {
            _shopPanel.SetActive(true);
            _transform.SetAsLastSibling();
        }

        public void OnClickExit()
        {
            _shopPanel.SetActive(false);
        }
    }
}