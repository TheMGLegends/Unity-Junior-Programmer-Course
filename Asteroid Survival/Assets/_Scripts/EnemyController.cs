using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.0f;

    private Transform target;
    private Vector2 travelDirection;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        target = FindFirstObjectByType<PlayerController>().transform;

        SetTravelDirection();
    }

    private void FixedUpdate()
    {
        rb2D.AddForce(movementSpeed * travelDirection);
    }

    public void SetTravelDirection()
    {
        travelDirection = (target.transform.position - transform.position).normalized;
    }
}
