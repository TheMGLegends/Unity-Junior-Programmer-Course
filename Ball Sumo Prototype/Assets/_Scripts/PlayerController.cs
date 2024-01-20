using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private float knockbackStrength = 10.0f;
    [SerializeField] private float powerupDuration = 5.0f;
    [SerializeField] private GameObject powerupIndicator;
    [SerializeField] private float powerupIndicatorYOffset = 0.0f;

    private Rigidbody rb;
    private Transform focalPoint;

    private float verticalInput;
    private float horizontalInput;

    private bool bHasPowerup = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = FindFirstObjectByType<RotateCamera>().transform;
    }

    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("HorizontalWASD");

        powerupIndicator.transform.position = new Vector3(transform.position.x, transform.position.y + powerupIndicatorYOffset, transform.position.z);
    }

    private void FixedUpdate()
    {
        Vector3 movementDirection = verticalInput * focalPoint.forward + horizontalInput * focalPoint.right;
        rb.AddForce(movementSpeed * movementDirection, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            bHasPowerup = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownCoroutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && bHasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * knockbackStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownCoroutine()
    {
        yield return new WaitForSeconds(powerupDuration);
        bHasPowerup = false;
        powerupIndicator.SetActive(false);
    }
}
