using UnityEngine;
using System.Collections.Generic;

public class Spawner2 : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;
    public List<GameObject> itemPrefabs;
    public float spawnInterval = 2f;
    public float[] lanePositions; 
    public float spawnXPosition = 15f;

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnObject()
    {
        bool spawnObstacle = Random.value < 0.75f;
        float lanePosition = lanePositions[Random.Range(0, lanePositions.Length)];


        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(spawnXPosition, lanePosition), 1f);
        if (colliders.Length == 0)
        {

            GameObject prefabToSpawn = spawnObstacle ? obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)] : itemPrefabs[Random.Range(0, itemPrefabs.Count)];


            Instantiate(prefabToSpawn, new Vector3(spawnXPosition, lanePosition, 0f), Quaternion.identity);
        }
    }
}
