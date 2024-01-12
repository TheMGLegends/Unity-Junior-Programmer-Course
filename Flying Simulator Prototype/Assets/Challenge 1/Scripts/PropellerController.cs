using UnityEngine;

public class PropellerController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1.0f;

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
