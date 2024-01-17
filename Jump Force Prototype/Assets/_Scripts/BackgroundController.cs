using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Vector3 startPosition;
    private BoxCollider boxCollider;
    private float repeatWidth;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();

        startPosition = transform.position;
        repeatWidth = boxCollider.size.x / 2;
    }

    private void Update()
    {
        if (transform.position.x < startPosition.x - repeatWidth)
            transform.position = startPosition;
    }
}
