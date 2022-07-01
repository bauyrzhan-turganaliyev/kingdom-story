using System;
using UnityEngine;

namespace turganaliyev.Jobs.Blacksmith
{
    public class BlacksmithService : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private OrderService _orderService;
        [SerializeField] private GameObject _blackSmithMainPanel;

        public Action OnOrderServiceOpened;
        public Action OnOrderServiceExit;
        public void Init()
        {
            _orderService.Init(ref OnOrderServiceOpened, ref OnOrderServiceExit);
        }

        public void OnClick()
        {
            _transform.SetAsLastSibling();
            _blackSmithMainPanel.SetActive(true);
            OnOrderServiceOpened?.Invoke();
        }
        
        public void OnExit()
        {
            _transform.SetAsLastSibling();
            _blackSmithMainPanel.SetActive(false);
            OnOrderServiceExit?.Invoke();
        }
    }
}