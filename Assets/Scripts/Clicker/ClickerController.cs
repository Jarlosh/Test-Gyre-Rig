using System;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker
{
    public class ClickerController : MonoBehaviour
    {
        //Actually this acrchitecture is overengineered, created just to follow requested MVC pattern 
        [SerializeField] private Button increaseButton;
        public event Action OnIncreaseClickedEvent;
        
        private void Start()
        {
            increaseButton.onClick.AddListener(OnIncreaseClicked);
        }

        private void OnDestroy()
        {
            increaseButton.onClick.RemoveListener(OnIncreaseClicked);
        }

        private void OnIncreaseClicked()
        {
            OnIncreaseClickedEvent?.Invoke();
        }
    }
}