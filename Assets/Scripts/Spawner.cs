using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Spawner2 : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;
    public List<GameObject> itemPrefabs;
    public float spawnInterval_p5_to_p2 = 0.5f;
    public float[] lanePositions;
    public float spawnXPosition = 15f;
    public float[] spawnInterval_p5_to_p2s = { 0.5f, 0.4f, 0.3f, 0.2f };
    public TextMeshProUGUI timerText; 
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI scoreText; 
    public GameObject gameOverCanvas; 

    private float nextSpawnTime;
    private int remainingTime; 
    private int intervalIndex;
    private bool spawningStopped;
    private bool gamePaused; 

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval_p5_to_p2;
        remainingTime = 80; 
        intervalIndex = 0;
        spawningStopped = false;
        gamePaused = false;

        if (timerText != null)
        {
            timerText.text = $"Time: {remainingTime}s";
        }

        gameOverCanvas.SetActive(false);

        StartCoroutine(TimerCoroutine());
    }

    void Update()
    {

        if (remainingTime <= 0 && !spawningStopped)
        {
            spawningStopped = true;
            StartCoroutine(PauseGameAfterDelay(5f));
            return;
        }

        if (!spawningStopped && intervalIndex < spawnInterval_p5_to_p2s.Length && remainingTime <= 80 - 20 * (intervalIndex + 1))
        {
            spawnInterval_p5_to_p2 = spawnInterval_p5_to_p2s[intervalIndex];
            intervalIndex++;
        }

        if (!spawningStopped && Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnInterval_p5_to_p2;
        }
    }

    IEnumerator TimerCoroutine()
    {
        while (remainingTime > 0 && !gamePaused)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;

            if (timerText != null)
            {
                timerText.text = $"Timer: {remainingTime}s";
                scoreText.text = $"Bummer! You only survived for {Mathf.Abs(remainingTime - 80)} seconds.";
            }

            if (levelText != null)
            {
                string level = GetLevelText(remainingTime);
                levelText.text = $"{level} Wave";
            }
        }
    }

    IEnumerator PauseGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 0f;
        gamePaused = true;
        
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }
    }

    string GetLevelText(int time)
    {
        if (time >= 61)
        {
            return "First";
        }
        else if (time >= 41)
        {
            return "Second";
        }
        else if (time >= 21)
        {
            return "Third";
        }
        else
        {
            return "Final";
        }
    }

    void SpawnObject()
    {
        bool spawnObstacle = Random.value < 0.70f;
        float lanePosition = lanePositions[Random.Range(0, lanePositions.Length)];

        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(spawnXPosition, lanePosition), 1f);
        if (colliders.Length == 0)
        {
            GameObject prefabToSpawn = spawnObstacle ? obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)] : itemPrefabs[Random.Range(0, itemPrefabs.Count)];
            Instantiate(prefabToSpawn, new Vector3(spawnXPosition, lanePosition, 0f), Quaternion.identity);
        }
    }
}
