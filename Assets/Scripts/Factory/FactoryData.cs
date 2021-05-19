using UnityEngine;

namespace Factory
{
    public class FactoryData : MonoBehaviour
    {
        [SerializeField] Transform moveDirection;
        [SerializeField] private InputValue distance;
        [SerializeField] private InputValue speed;

        public MoveInfo MakeInfo()
        {
            return new MoveInfo()
            {
                distance = distance.Value,
                speed = speed.Value,
                worldDirection = moveDirection.forward
            };
        }
    }
}