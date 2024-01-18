using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10.0f;
    [SerializeField] private float lifetimeDuration = 5.0f;

    private float lifeTime = 0.0f;

    private void Update()
    {
        lifeTime += Time.deltaTime;

        if (lifeTime > lifetimeDuration)
            Destroy(gameObject);

        transform.Translate(bulletSpeed * Time.deltaTime * Vector3.up);
    }
}
