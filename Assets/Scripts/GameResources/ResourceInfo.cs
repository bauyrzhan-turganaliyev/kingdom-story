using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace oks.GameResources
{
    public class ResourceInfo : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TMP_Text NameOfResourceText;
        [SerializeField] private TMP_Text PriceOfResourceText;
        [SerializeField] private Image _image;

        public Action<ResourceInfo, bool> ResourceClicked;
        
        public string NameOfResource;
        public int Price;
        public bool IsSelected;
        public bool IsInPlayer;
        public Resource Resource;

        public void Init(Resource resource, bool isInPlayer)
        {
            Resource = resource;
            NameOfResource = resource.Name;
            Price = resource.AveragePrice;

            IsInPlayer = isInPlayer;
            NameOfResourceText.text = NameOfResource;
            PriceOfResourceText.text = Price.ToString();
            
            _image.color = Color.white;
        }
        public string GetName()
        {
            return NameOfResource;
        }

        public void TransferToPlayer()
        {
            IsInPlayer = true;
            IsSelected = false;
            
            OnDiselect();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (IsSelected)
            {
                OnDiselect();
                ResourceClicked?.Invoke(this, false);
            }
            else
            {
                OnSelect();
                ResourceClicked?.Invoke(this, true);
            }
        }

        public void OnSelect()
        {
            _image.color = Color.green;
            IsSelected = true;
        }

        public void OnDiselect()
        {
            _image.color = Color.white;
            IsSelected = false;
        }
    }
}