using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    [SerializeField] private float spawnDelay = 0.5f;

    private float spawnTimer = 0.0f;
    private bool bCanSpawn = false;

    // Update is called once per frame
    void Update()
    {
        // INFO: Prevents dogs from being spawned instantly
        if (!bCanSpawn)
            spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnDelay )
        {
            spawnTimer = 0.0f;
            bCanSpawn = true;
        }

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && bCanSpawn)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            bCanSpawn = false;
        }
    }
}
