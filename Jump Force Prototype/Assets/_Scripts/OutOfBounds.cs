using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] private float leftBound = 0.0f;

    private void Update()
    {
        if (transform.position.x < leftBound)
            Destroy(gameObject);
    }
}
