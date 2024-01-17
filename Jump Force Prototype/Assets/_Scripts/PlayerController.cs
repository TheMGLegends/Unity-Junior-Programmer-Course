using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1.0f;
    [SerializeField] private float gravityModifier = 1.0f;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float rayLength = 1.0f;

    private Rigidbody rb;
    private BoxCollider boxCollider;
    private Animator animator;

    private bool bIsGrounded = true;
    private bool bIsGameOver = false;

    public bool GetIsGameOver() => bIsGameOver;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();

        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !bIsGameOver)
        {
            bIsGrounded = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump_trig");
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            bIsGameOver = true;
            animator.SetBool("Death_b", true);
        }
    }
}
