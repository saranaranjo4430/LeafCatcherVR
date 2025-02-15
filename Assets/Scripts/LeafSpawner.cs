using UnityEngine;

public class LeafSpawner : MonoBehaviour
{
    public GameObject leafPrefab; // Assign the leaf prefab in the Inspector
    public float initialSpawnInterval = 1f; // Initial time between spawns
    public float spawnRateIncrease = 0.05f; // How much to decrease the interval over time
    public float minSpawnInterval = 0.4f; // The fastest spawn rate
    public int initialBatchSize = 1; // Starting number of leaves per batch
    public float spawnRadius = 1f; // Small radius around the player
    public float throwForce = 1f; // Force to throw leaves toward the player
    public Transform playerCamera; // Reference to the player's camera for direction

    private float spawnInterval; // Current time between spawns
    private int batchSize; // Current batch size
    private float timeSinceLastSpawn = 0f; // Tracks time since the last spawn

    void Start()
    {
        // Initialize spawn settings
        spawnInterval = initialSpawnInterval;
        batchSize = initialBatchSize;
    }

    void Update()
    {
        // Spawn leaves at intervals
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnLeafBatch();
            timeSinceLastSpawn = 0f;

            // Gradually increase spawn rate
            if (spawnInterval > minSpawnInterval)
            {
                spawnInterval -= spawnRateIncrease;
            }
        }
    }

    void SpawnLeafBatch()
    {
        for (int i = 0; i < batchSize; i++)
        {
            // Spawn position: slightly in front of the player's camera, within a specific range
            float spawnDistance = Random.Range(0.3f, 1f); // Distance from the player
            float spawnHeight = Random.Range(30f, 35f); // Height above the ground (increased)
            float horizontalOffset = Random.Range(-spawnRadius, spawnRadius); // Horizontal offset (left/right)

            // Calculate spawn position in front of the player
            Vector3 spawnPos = playerCamera.position + playerCamera.forward * spawnDistance;
            spawnPos += playerCamera.right * horizontalOffset; // Add some horizontal randomness
            spawnPos += Vector3.up * spawnHeight; // Add height to the spawn position

            // Instantiate the leaf
            GameObject leaf = Instantiate(leafPrefab, spawnPos, Quaternion.identity);

            // Apply a forward velocity to make the leaves fall toward the player
            Rigidbody leafRb = leaf.GetComponent<Rigidbody>();
            if (leafRb != null)
            {
                Vector3 throwDirection = (playerCamera.position - spawnPos).normalized;
                leafRb.velocity = throwDirection * throwForce;
            }
        }
    }
}
