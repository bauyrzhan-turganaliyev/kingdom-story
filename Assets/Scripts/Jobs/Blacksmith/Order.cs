using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace oks.Jobs.Blacksmith
{
    public class Order : MonoBehaviour
    {
        [SerializeField] private TMP_Text _whatNeedText;
        [SerializeField] private TMP_Text _pieceText;
        
        private List<string> _objectsList = new List<string>(){ "Меч", "Двуручный меч", "Булава", "Щит", "Топор"};
        public float Price;
        public string NameOfObject;
        public int Piece;
        public void Init()
        {
            NameOfObject = _objectsList[Random.Range(0, _objectsList.Count)];
            Piece = Random.Range(1, 3);
            Price = Random.Range(1, 5) * Piece;
            
            
            _whatNeedText.text = NameOfObject;
            _pieceText.text = Piece + " шт";
        }
    }
}