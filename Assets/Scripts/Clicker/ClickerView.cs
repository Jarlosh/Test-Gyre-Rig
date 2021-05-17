using TMPro;
using UnityEngine;

namespace Clicker
{
    public class ClickerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text counter;
        [SerializeField] private ClickerModel model;

        private void Start()
        {
            model.OnScoreChangedEvent += OnScoreChanged;
            OnScoreChanged(model.Score);
        }

        private void OnDestroy()
        {
            model.OnScoreChangedEvent -= OnScoreChanged;
        }

        private void OnScoreChanged(int score)
        {
            SetScore(score);
        }

        private void SetScore(int score)
        {
            counter.SetText(score.ToString());
        }
    }
}