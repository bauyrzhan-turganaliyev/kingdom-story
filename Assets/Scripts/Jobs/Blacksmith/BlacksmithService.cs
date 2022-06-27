using UnityEngine;

namespace turganaliyev.Jobs.Blacksmith
{
    public class BlacksmithService : MonoBehaviour
    {
        [SerializeField] private OrderService _orderService;
        [SerializeField] private GameObject _blackSmithMainPanel;
        [SerializeField] private GameObject _questionToQuitPanel;

        private bool _isActive;
        public void Init()
        {
            _orderService.Init();
        }

        public void OnClick()
        {
            if (!_isActive)
            {
                _blackSmithMainPanel.SetActive(true);
                _isActive = true;
            }
            else
            {
                _questionToQuitPanel.SetActive(true);   
            }
        }


        public void QuestionToQuit(bool flag)
        {
            _questionToQuitPanel.SetActive(false);
            _isActive = !flag;
            if (flag)
            {
                _blackSmithMainPanel.SetActive(false);
            }
        }

        public void OnYes()
        {
            QuestionToQuit(true);
        }
        
        public void OnNo()
        {
            QuestionToQuit(false);
        }
     }
}