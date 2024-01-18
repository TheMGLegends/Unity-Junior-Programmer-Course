using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Jump Settings:")]
    [SerializeField] private float jumpForce = 1.0f;
    [SerializeField] private float gravityModifier = 1.0f;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float rayLength = 1.0f;

    [Header("Particles:")]
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;

    [Header("Sound Effects:")]
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip crashSFX;

    private Rigidbody rb;
    private BoxCollider boxCollider;
    private Animator animator;
    private AudioSource audioSource;

    private bool bIsGrounded = true;
    private bool bIsGameOver = false;

    public bool GetIsGameOver() => bIsGameOver;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

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
            dirtParticle.Stop();
            audioSource.PlayOneShot(jumpSFX, 1.0f);
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
        boxCollider = GetComponent<BoxCollider>();

        Gizmos.color = Color.red;
        Gizmos.DrawLine(boxCollider.bounds.center, boxCollider.bounds.center + Vector3.down * (rayLength + boxCollider.bounds.extents.y));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            bIsGameOver = true;
            dirtParticle.Stop();
            audioSource.PlayOneShot(crashSFX, 1.0f);
            explosionParticle.Play();
            animator.SetBool("Death_b", true);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            dirtParticle.Play();
        }
    }
}
