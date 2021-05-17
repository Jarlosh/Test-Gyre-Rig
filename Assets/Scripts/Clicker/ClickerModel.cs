using System;
using UnityEngine;

namespace Clicker
{
    public class ClickerModel : MonoBehaviour
    {
        private const string scorePrefKey = "clickerScore";
        [SerializeField] private ClickerController controller;
        [SerializeField] private bool usePlayerPrefs;
        [SerializeField] private int score;
        
        public int Score 
        {
            get => score;
            private set
            {
                if (value == score)
                    return;
                
                score = value;
                if(usePlayerPrefs)
                    PlayerPrefs.SetInt(scorePrefKey, score);
                OnScoreChangedEvent?.Invoke(score);
            } 
        }

        public event Action<int> OnScoreChangedEvent;
        
        private void Start()
        {
            if (usePlayerPrefs)
                Score = PlayerPrefs.GetInt(scorePrefKey, 0);
            controller.OnIncreaseClickedEvent += OnIncreaseClicked;
        }

        private void OnDestroy()
        {
            controller.OnIncreaseClickedEvent -= OnIncreaseClicked;
        }

        private void OnIncreaseClicked()
        {
            Score++;
        }
    }
}