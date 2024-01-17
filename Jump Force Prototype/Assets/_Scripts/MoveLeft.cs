using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1.0f;

    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = FindFirstObjectByType<PlayerController>();
    }

    private void Update()
    {
        if (!playerControllerScript.GetIsGameOver())
            transform.Translate(movementSpeed * Time.deltaTime * Vector3.left);
    }
}
