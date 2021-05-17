using System;
using Factory.UIStuff;
using UnityEngine;

namespace Factory
{
    public class FactoryData : MonoBehaviour
    {
        [SerializeField] Transform moveDirection;
        [SerializeField] private InputBox distanceInput;
        [SerializeField] private InputBox speedInput;

        [SerializeField] private float distance = 1;
        [SerializeField] private float speed = 1; 
        
        [SerializeField] private float minDistance = 1;
        [SerializeField] private float minSpeed = 1;
        
        public float Speed
        {
            get => speed;
            set
            {
                if (speed == value)
                    return;
                speed = value;
            }
        }
        public float Distance
        {
            get => distance;
            set
            {
                if (distance == value)
                    return;
                distance = value;
            }
        }

        private void Start()
        {
            speedInput.OnValueSubmit += OnSpeedSubmit;
            distanceInput.OnValueSubmit += OnDistanceSubmit;
            speedInput.SetValue(speed);
            distanceInput.SetValue(distance);
        }

        private void OnDestroy()
        {
            speedInput.OnValueSubmit -= OnSpeedSubmit;
            distanceInput.OnValueSubmit -= OnDistanceSubmit;
        }

        private void OnSpeedSubmit(InputBox box, float val)
        {
            speed = Mathf.Max(val, minSpeed);
            box.SetValue(speed);
        }
        
        private void OnDistanceSubmit(InputBox box, float val)
        {
            distance = Mathf.Max(val, minDistance);
            box.SetValue(distance);
        }

        public MoveInfo MakeInfo()
        {
            return new MoveInfo()
            {
                distance = Distance,
                speed = Speed,
                worldDirection = moveDirection.forward
            };
        }
    }
}