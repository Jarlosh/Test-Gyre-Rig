using System;
using UnityEngine;

namespace Factory
{
    public struct MoveInfo
    {
        public float speed;
        public float distance;
        public Vector3 worldDirection;

        public Vector3 VelocityVector => speed * worldDirection;
    }
    
    public class MovingBlock : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        
        private MoveInfo moveInfo;
        private Vector3 launchPoint;
        private bool isMoving;
        
        public event Action OnMoveCompleteEvent;
        public Transform LookTarget => rb.transform;
        
        
        public void Launch(MoveInfo moveInfo)
        {
            this.moveInfo = moveInfo;
            isMoving = true;
            launchPoint = rb.position;
        }

        public void Update()
        {
            if (isMoving)
            {
                rb.velocity = moveInfo.VelocityVector;
                if(IsMoveComplete)
                    DestroySelf();
            }
        }

        private void DestroySelf()
        {
            OnMoveCompleteEvent?.Invoke();
            Destroy(gameObject);
        }

        public bool IsMoveComplete => Vector3.Distance(rb.position, launchPoint) >= moveInfo.distance;
    }
}