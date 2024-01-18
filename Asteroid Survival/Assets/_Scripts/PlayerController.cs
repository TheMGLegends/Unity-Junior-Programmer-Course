using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private float drag = 0.0f;

    [SerializeField] private float topBorder;
    [SerializeField] private float bottomBorder;
    [SerializeField] private float leftBorder;
    [SerializeField] private float rightBorder;

    private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 mousePosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = drag;
    }

    private void Update()
    {
        GetInputAxis();
        BorderPlayer();

        ShootBullet();
        RotateShip();
    }

    private void FixedUpdate()
    {
        // INFO: Update Spaceship Position
        rb.AddForce(movementSpeed * verticalInput * transform.up + horizontalInput * movementSpeed * transform.right);
    }

    private void GetInputAxis()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void BorderPlayer()
    {
        if (transform.position.y > topBorder)
            transform.position = new(transform.position.x, bottomBorder, transform.position.z);
        else if (transform.position.y < bottomBorder)
            transform.position = new(transform.position.x, topBorder, transform.position.z);

        if (transform.position.x < leftBorder)
            transform.position = new(rightBorder, transform.position.y, transform.position.z);
        else if (transform.position.x > rightBorder)
            transform.position = new(leftBorder, transform.position.y, transform.position.z);
    }

    private void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    private void RotateShip()
    {
        // INFO: Update Spaceship Rotation
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 facingDirection = mousePosition - transform.position;
        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
