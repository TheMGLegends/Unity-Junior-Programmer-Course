using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private Vector3 spawnPosition;

    private void Start()
    {
        Instantiate(obstaclePrefabs[0], spawnPosition, obstaclePrefabs[0].transform.rotation);
    }
}
