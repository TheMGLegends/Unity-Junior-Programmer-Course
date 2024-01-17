using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.0f;

    private void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime * Vector3.left);
    }
}
