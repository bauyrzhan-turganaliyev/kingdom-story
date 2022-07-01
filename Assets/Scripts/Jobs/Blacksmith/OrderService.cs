using System;
using TMPro;
using UnityEngine;

namespace turganaliyev.Jobs.Blacksmith
{
    public class OrderService : MonoBehaviour
    {
        [SerializeField] private GameObject _orderPrefab;
        [SerializeField] private Transform _parentTransform;

        private int _ordersCount;
        private float nextUpdate = 1f;
        private bool _isOpened;
        
        public void Init(ref Action OnOrderServiceOpened, ref Action OnOrderServiceExit)
        {
            OnOrderServiceOpened += ServiceOpened;
            OnOrderServiceExit += ServiceExit;
        }

        void Update()
        {
            if (Time.time >= nextUpdate && _ordersCount < 10 && _isOpened)
            {
                nextUpdate = Time.time + 1f;
                UpdateEverySecond();
            }
        }

        void UpdateEverySecond()
        {
            var order = Instantiate(_orderPrefab, _parentTransform);
            var orderComponent = order.GetComponent<Order>();

            orderComponent.Init();

            _ordersCount++;
        }

        private void ServiceOpened()
        {
            print("Called");
            _isOpened = true;
        }
        private void ServiceExit()
        {
            print("Called");
            _isOpened = false;
        }
    }
}