using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.0f;

    private Rigidbody rb;
    private Transform focalPoint;

    private float verticalInput;
    private float horizontalInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = FindFirstObjectByType<RotateCamera>().transform;
    }

    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("HorizontalWASD");
    }

    private void FixedUpdate()
    {
        Vector3 movementDirection = verticalInput * focalPoint.forward + horizontalInput * focalPoint.right;
        rb.AddForce(movementSpeed * movementDirection, ForceMode.VelocityChange);
    }
}
