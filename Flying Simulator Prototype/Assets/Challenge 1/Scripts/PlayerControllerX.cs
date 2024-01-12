using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private float rotationSpeed = 1.0f;
    [SerializeField] private float verticalInput = 0.0f;

    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(movementSpeed * Time.deltaTime * Vector3.forward);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(rotationSpeed * Time.deltaTime * verticalInput * Vector3.right);
    }
}
