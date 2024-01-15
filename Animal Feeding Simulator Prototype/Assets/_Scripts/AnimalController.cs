using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private float zBoundary = -10.0f;

    private void Update()
    {
        // INFO: Destroy Self if outside game view
        if (transform.position.z < zBoundary)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }

        // INFO: Move the animal forward
        transform.Translate(movementSpeed * Time.deltaTime * Vector3.forward);
    }
}
