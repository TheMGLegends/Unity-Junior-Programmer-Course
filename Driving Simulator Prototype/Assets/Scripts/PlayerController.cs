using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalInput = 0.0f;
    [SerializeField] private float verticalInput = 0.0f;

    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private float turnSpeed = 1.0f;

    private void Update()
    {
        // INFO: Get User Input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // INFO: Moves Forward Scaled with Time
        transform.Translate(movementSpeed * Time.deltaTime * verticalInput * Vector3.forward);

        // INFO: Rotates Object in the Y-Axis
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * turnSpeed);
    }
}
