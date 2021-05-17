using System;
using UnityEngine;

namespace Factory
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GameObject prefab;

        public MovingBlock Spawn()
        {
            var go = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation, container);
            return go.GetComponent<MovingBlock>();
        }
    }
}