using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;

    [SerializeField] private Vector2 spawnAreaMin;
    [SerializeField] private Vector2 spawnAreaMax;

    [SerializeField] private List<Rect> exclusionAreas = new();

    private List<GameObject> spawnedAsteroids = new();

    private void Start()
    {
        SpawnAsteroids(10);
    }

    private void Update()
    {
        foreach (GameObject asteroid in spawnedAsteroids)
        {
            if (asteroid.transform.position.x < spawnAreaMin.x || asteroid.transform.position.x > spawnAreaMax.x ||
                asteroid.transform.position.y < spawnAreaMin.y || asteroid.transform.position.y > spawnAreaMax.y)
            {
                asteroid.GetComponent<EnemyController>().SetTravelDirection();
            }
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < exclusionAreas.Count; i++)
        {
            DrawRectGizmoMesh(exclusionAreas[i], Color.green);
        }
    }

    private void DrawRectGizmoMesh(Rect rect, Color color)
    {
        Gizmos.color = color;

        // INFO: Draw Horizontal Lines
        Gizmos.DrawLine(new Vector3(rect.x, rect.y, 0), new Vector3(rect.x + rect.width, rect.y, 0));
        Gizmos.DrawLine(new Vector3(rect.x, rect.y + rect.height, 0), new Vector3(rect.x + rect.width, rect.y + rect.height, 0));

        // INFO: Draw Vertical Lines
        Gizmos.DrawLine(new Vector3(rect.x, rect.y, 0), new Vector3(rect.x, rect.y + rect.height, 0));
        Gizmos.DrawLine(new Vector3(rect.x + rect.width, rect.y, 0), new Vector3(rect.x + rect.width, rect.y + rect.height, 0));
    }

    private void SpawnAsteroids(int asteroidCount)
    {
        for (int i = 0; i < asteroidCount; i++)
        {
            GameObject GO = Instantiate(asteroidPrefab, GetRandomPosition(), asteroidPrefab.transform.rotation);
            spawnedAsteroids.Add(GO);
        }
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 randomPos;

        do
        {
            randomPos = new(Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                            Random.Range(spawnAreaMin.y, spawnAreaMax.y));
        }
        while (IsPositionInExclusionZone(randomPos));

        return randomPos;
    }

    private bool IsPositionInExclusionZone(Vector2 position)
    {
        foreach (Rect rect in exclusionAreas)
        {
            if (rect.Contains(position))
                return true;
        }
        return false;
    }
}
