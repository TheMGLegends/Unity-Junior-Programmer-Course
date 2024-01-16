using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private bool bChangeAtStart = false;

    [SerializeField] private Vector3 position = Vector3.zero;
    [SerializeField] private float scale = 1.0f;
    [SerializeField] private float rotationAngle = 10.0f;
    [SerializeField] private float rotationSpeed = 1.0f;
    [SerializeField] private Color materialColor = Color.white;
    [SerializeField] private Color lerpedColor = Color.green;

    private MeshRenderer meshRenderer;
    private float lerpTime = 0.0f;

    void Start()
    {
        if (bChangeAtStart)
        {
            scale = Random.Range(0.5f, 10.0f);
            rotationAngle = Random.Range(10.0f, 360.0f);
            rotationSpeed = Random.Range(1.0f, 10.0f);
        }

        meshRenderer = GetComponent<MeshRenderer>();

        transform.position = position;
        transform.localScale = Vector3.one * scale;

        Material material = meshRenderer.material;

        material.color = materialColor;
    }

    void Update()
    {
        meshRenderer.material.color = Color.Lerp(materialColor, lerpedColor, Mathf.PingPong(lerpTime, 1));

        lerpTime += Time.deltaTime;

        transform.Rotate(rotationAngle * Time.deltaTime * rotationSpeed, 0.0f, 0.0f);
    }
}
