using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject bonusPrefab;
    public float spawnInterval = 2f;
    public float spawnPositionX = 10f;
    public PlayerController playerController; // Ensure this is assigned in the Inspector or via code

    private void Start()
    {
        // Ensure playerController is assigned
        if (playerController == null)
        {
            Debug.LogError("PlayerController reference not set in Spawner.");
            return;
        }

        // Start the spawning process
        InvokeRepeating("SpawnObject", spawnInterval, spawnInterval);
    }

    void SpawnObject()
    {
        // Determine which prefab to spawn (obstacle or bonus)
        GameObject prefabToSpawn = (Random.value > 0.5f) ? obstaclePrefab : bonusPrefab;

        // Access the lanePositions array from the PlayerController
        float[] lanePositions = playerController.lanePositions;

        // Choose a random lane index
        int laneIndex = Random.Range(0, lanePositions.Length);

        // Get the spawn position based on the chosen lane
        float spawnPositionY = lanePositions[laneIndex];
        Vector3 spawnPosition = new Vector3(spawnPositionX, spawnPositionY, 0);

        // Instantiate the chosen prefab at the calculated position
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
