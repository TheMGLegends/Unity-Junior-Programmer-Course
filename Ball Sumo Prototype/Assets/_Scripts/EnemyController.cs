using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.0f;

    private Rigidbody rb;
    private Transform player;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindFirstObjectByType<PlayerController>().transform;
    }

    private void Update()
    {
        if (transform.position.y < -10)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        // INFO: Move in the direction of the player at a constant speed no matter the distance
        Vector3 lookDirection = (player.position - transform.position).normalized;
        rb.AddForce(movementSpeed * lookDirection, ForceMode.VelocityChange);
    }
}
