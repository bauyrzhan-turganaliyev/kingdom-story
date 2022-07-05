using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace oks.GameResources
{
    public class ResourceInfo : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TMP_Text _nameOfResourceText;
        [SerializeField] private TMP_Text _priceOfResourceText;
        [SerializeField] private Image _image;

        public Action<Resource, bool> ResourceClicked;
        
        private string _nameOfResource;
        private int _price;
        private bool _isSelected;
        private Resource _resource;

        public void Init(Resource resource)
        {
            _resource = resource;
            _nameOfResource = resource.Name;
            _price = resource.AveragePrice;

            _nameOfResourceText.text = _nameOfResource;
            _priceOfResourceText.text = _price.ToString();
            
            _image.color = Color.white;
        }

        public string GetName()
        {
            return _nameOfResource;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_isSelected)
            {
                _image.color = Color.white;
                _isSelected = false;
                ResourceClicked?.Invoke(_resource, false);
            }
            else
            {
                _image.color = Color.green;
                _isSelected = true;
                ResourceClicked?.Invoke(_resource, true);
            }
        }
    }
}