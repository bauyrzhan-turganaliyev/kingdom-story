using turganaliyev.Jobs.Blacksmith;
using UnityEngine;

namespace Core
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private BlacksmithService _blacksmithService;
        private void Start()
        {
            _blacksmithService.Init();
        }
    }
}
