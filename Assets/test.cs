using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace turganaliyev
{
    public class test : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Image _image;
        [SerializeField] private Color _onOver;
        [SerializeField] private Color _notHover;
        [SerializeField] private AudioSource _audio;
        private void Start()
        {
            _image.color = _notHover;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _audio.Play();
            _image.color = _onOver;
            _transform.localScale += new Vector3(0.25F, 0, 0);
            transform.SetAsLastSibling();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _audio.Stop();
            _image.color = _notHover;
            _transform.localScale -= new Vector3(0.25F, 0, 0);
            transform.SetAsFirstSibling();

        }
    }
}
