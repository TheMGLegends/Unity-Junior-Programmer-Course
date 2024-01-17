using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float spawnInterval = 1.0f;

    private PlayerController playerControllerScript;
    private float spawnTime = 0.0f;

    private void Start()
    {
        playerControllerScript = FindFirstObjectByType<PlayerController>();
    }

    private void Update()
    {
        if (!playerControllerScript.GetIsGameOver())
        {
            spawnTime += Time.deltaTime;

            if (spawnTime > spawnInterval)
            {
                spawnTime = 0.0f;
                SpawnObstacle();
            }
        }
        else
            spawnTime = 0.0f;
    }

    private void SpawnObstacle()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Count);
        Instantiate(obstaclePrefabs[obstacleIndex], spawnPosition, obstaclePrefabs[obstacleIndex].transform.rotation);
    }
}
