using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private float xBoundaryRange = 10.0f;
    [SerializeField] private List<GameObject> projectilePrefabs = new();

    private float horizontalInput;

    private void Update()
    {
        GetInputAxis();
        DetectBoundaries();
        Move();
        InstantiateFood();
    }
    private void GetInputAxis()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void DetectBoundaries()
    {
        // INFO: Left-most Boundary and Right-most Boundary
        if (transform.position.x < -xBoundaryRange)
            transform.position = new Vector3(-xBoundaryRange, transform.position.y, transform.position.z);
        else if (transform.position.x > xBoundaryRange)
            transform.position = new Vector3(xBoundaryRange, transform.position.y, transform.position.z);
    }

    private void Move()
    {
        // INFO: Prevents Stutter Movement when walking into boundary
        if (transform.position.x <= -xBoundaryRange && horizontalInput < 0 || transform.position.x >= xBoundaryRange && horizontalInput > 0)
        {
            transform.Translate(Vector3.zero);
            return;
        }

        // INFO: Move Player Left & Right
        transform.Translate(horizontalInput * movementSpeed * Time.deltaTime * Vector3.right);
    }

    private void InstantiateFood()
    {
        // INFO: Instantiate a random food from the foods list at the players position
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int foodIndex = Random.Range(0, projectilePrefabs.Count);
            Instantiate(projectilePrefabs[foodIndex], transform.position, projectilePrefabs[foodIndex].transform.rotation);
        }
    }
}
