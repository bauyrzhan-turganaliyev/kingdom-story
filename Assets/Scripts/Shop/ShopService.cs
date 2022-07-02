using UnityEngine;

namespace turganaliyev.Shop
{
    public class ShopService : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _shopPanel;

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