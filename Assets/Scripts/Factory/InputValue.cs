using System;
using Factory.UIStuff;
using UnityEngine;

namespace Factory
{
    public class InputValue : MonoBehaviour
    {
        [SerializeField] private InputBox inputBox;
        [SerializeField] private float value = 1;
        [SerializeField] private float minValue = 1;
        [SerializeField] private float maxValue = 100;
        public float Value
        {
            get => value;
            set
            {
                if (this.value == value)
                    return;
                this.value = value;
                inputBox.SetValue(this.value);
            }
        }
        
        private void Start()
        {
            inputBox.OnValueSubmit += OnValueSubmit;
            inputBox.SetValue(Value);
        }
        
        private void OnDestroy()
        {
            inputBox.OnValueSubmit -= OnValueSubmit;
        }
        
        private void OnValueSubmit(float value)
        {
            Value = Mathf.Clamp(value, minValue, maxValue);
        }
    }
}