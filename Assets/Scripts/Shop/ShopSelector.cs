using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace oks.Shop
{
    public class ShopSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
    {
        public ShopSelectorType Type;
        [SerializeField] private Transform _transform;
        [SerializeField] private Image _image;
        [SerializeField] private Color _onOver;
        [SerializeField] private Color _notHover;
        [SerializeField] private AudioSource _audio;

        public Action<ShopSelector> OnClicked;
        
        private void OnEnable()
        {
            _image.color = _notHover;
            _transform.localScale = new Vector3(1, 1, 1);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _audio.Play();
            _image.color = _onOver;
            _transform.localScale = new Vector3(1.25f, 1, 1);
            transform.SetAsLastSibling();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _audio.Stop();
            _image.color = _notHover;
            _transform.localScale = new Vector3(1f, 1, 1);
            transform.SetAsFirstSibling();
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked?.Invoke(this);
            print($"{name} clicked");
        }
    }
}
