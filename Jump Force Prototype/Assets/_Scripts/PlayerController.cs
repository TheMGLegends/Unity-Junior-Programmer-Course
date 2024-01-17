using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1.0f;
    [SerializeField] private float gravityModifier = 1.0f;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float rayLength = 1.0f;

    private Rigidbody rb;
    private BoxCollider boxCollider;
    private bool bIsGrounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();

        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            bIsGrounded = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        bIsGrounded = Physics.Raycast(boxCollider.bounds.center, Vector3.down, boxCollider.bounds.extents.y + rayLength, groundLayers);
        return bIsGrounded;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, Vector3.down * rayLength);
    }
}
