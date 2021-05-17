using UnityEngine;

namespace Factory
{
    public class FactoryData : MonoBehaviour
    {
        [SerializeField] Transform moveDirection;

        public float distance;
        public float speed;
        
        public MoveInfo MakeInfo()
        {
            return new MoveInfo()
            {
                distance = distance,
                speed = speed,
                worldDirection = moveDirection.forward
            };
        }
    }
}