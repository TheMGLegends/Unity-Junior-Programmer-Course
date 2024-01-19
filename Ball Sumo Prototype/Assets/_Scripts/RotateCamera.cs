using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1.0f;

    private float horizontalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxis("HorizontalKey");

        transform.Rotate(Vector3.up, rotationSpeed * horizontalInput * Time.deltaTime);
    }
}
