using System;
using TMPro;
using UnityEngine;

namespace Factory.UIStuff
{
    public class InputBox : MonoBehaviour
    {
        [SerializeField] private TMP_InputField field;
        public event Action<float> OnValueSubmit; 
        
        public void SetValue(float value)
        {
            field.text = value.ToString();
        }
        
        private void Start()
        {
            field.onSubmit.AddListener(OnSubmit);
        }

        private void OnDestroy()
        {
            field.onSubmit.RemoveListener(OnSubmit);
        }

        private void OnSubmit(string val)
        {
            if (float.TryParse(val, out var res))
                OnValueSubmit?.Invoke(res);
        }
    }
}