using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 targetOffset;

    void Update()
    {
        transform.position = target.position + targetOffset;
    }
}
