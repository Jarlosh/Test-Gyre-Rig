using UnityEngine;

namespace Factory
{
    public class LauncherMind : MonoBehaviour
    {
        [SerializeField] private FactoryData data;
        [SerializeField] private Spawner spawner;
        [SerializeField] private CameraController cameraMind; 
        private MovingBlock current;

        private void Start()
        {
            Launch();
        }
        
        private void Launch()
        {
            current = spawner.Spawn();
            current.Launch(data.MakeInfo());
            current.OnMoveCompleteEvent += OnComplete;
            
            cameraMind.SetTarget(current.LookTarget);
        }

        private void OnComplete()
        {
            current.OnMoveCompleteEvent -= OnComplete;
            cameraMind.SetNextCamera();
            Launch();
        }
    }
}