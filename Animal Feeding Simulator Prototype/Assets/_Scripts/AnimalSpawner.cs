using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> animalPrefabs = new();
    [SerializeField] private float spawnInterval = 2.5f;
    [SerializeField] private float xSpawnRange = 14.0f;
    [SerializeField] private float zSpawnPosition = 25.0f;

    private float spawnTime = 0.0f;

    private void Update()
    {
        spawnTime += Time.deltaTime;

        if (spawnTime > spawnInterval)
        {
            spawnTime = 0.0f;
            SpawnRandomAnimal();
        }
    }

    private void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Count);
        Vector3 spawnPosition = new(Random.Range(-xSpawnRange, xSpawnRange), 0, zSpawnPosition);

        Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);
    }
}
