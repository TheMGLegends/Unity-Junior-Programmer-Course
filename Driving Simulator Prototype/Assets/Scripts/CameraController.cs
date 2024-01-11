using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 targetOffset;

    private void LateUpdate()
    {
        // INFO: Camera Follows Target with Offset
        transform.position = target.position + targetOffset;
    }
}
