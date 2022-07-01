using System;
using UnityEngine;

namespace turganaliyev.UI
{
    [System.Serializable]
    public class QuestionToQuit
    {
        [SerializeField] private GameObject _questionToQuitPanel;

        public Action OnQuit;
        public Action<bool, GameObject> OnSelect;

        public void OnClickToQuit()
        {
            _questionToQuitPanel.SetActive(true);
        }

        public void OnSelectToQuit(bool flag, GameObject panel)
        {
            if (flag)
            {
                panel.SetActive(false);
                _questionToQuitPanel.SetActive(true);
            }
            else
            {
                _questionToQuitPanel.SetActive(false);
            }
        }
    }
}