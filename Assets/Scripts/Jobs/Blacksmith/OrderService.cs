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
        
        public void Init()
        {
        }

        void Update()
        {
            if (Time.time >= nextUpdate && _ordersCount < 10)
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
    }
}