using System;
using UnityEngine;

namespace turganaliyev.Jobs.Blacksmith
{
    public class BlacksmithService : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private OrderService _orderService;
        [SerializeField] private GameObject _blackSmithMainPanel;

        public Action OnServiceOpened;
        public Action OnServiceExit;
        public void Init()
        {
            _orderService.Init(this);
        }

        public void OnClick()
        {
            _transform.SetAsLastSibling();
            _blackSmithMainPanel.SetActive(true);
            OnServiceOpened?.Invoke();
        }
        
        public void OnExit()
        {
            _transform.SetAsLastSibling();
            _blackSmithMainPanel.SetActive(false);
            OnServiceExit?.Invoke();
        }
    }
}