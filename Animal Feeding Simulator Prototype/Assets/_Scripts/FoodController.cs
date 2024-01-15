using UnityEngine;

public class FoodController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private float rotationSpeed = 1.0f;
    [SerializeField] private float zBoundary = 10.0f;
    [SerializeField] private Transform food;

    private void Update()
    {
        // INFO: Destroy Self if outside game view
        if (transform.position.z > zBoundary)
            Destroy(gameObject);

        // INFO: Move the Food Forward
        transform.Translate(movementSpeed * Time.deltaTime * Vector3.forward);

        // INFO: Rotate the Food along the y-axis
        food.Rotate(rotationSpeed * Time.deltaTime * Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<AnimalController>() != null)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
