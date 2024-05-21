using UnityEngine;
using System.Collections;

public class RockCollision : MonoBehaviour
{
    public float obstacleMovementSpeed = 5f; 
    public float destroyThreshold = -15f;

    private Color originalColor;
    private Renderer rockRenderer;
    private float[] speedIncreaseIntervals = { 20f, 40f, 60f }; 
    private float[] speedTiers = { 7f, 9f, 11f }; 

    void Start()
    {
        rockRenderer = GetComponent<Renderer>();
        originalColor = rockRenderer.material.color;
    }

    void Update()
    {
        transform.Translate(Vector3.left * obstacleMovementSpeed * Time.deltaTime);


        for (int i = 0; i < speedIncreaseIntervals.Length; i++)
        {
            if (Time.time >= speedIncreaseIntervals[i] && obstacleMovementSpeed < speedTiers[i])
            {
                obstacleMovementSpeed = speedTiers[i];
                break; 
            }
        }


        if (transform.position.x < destroyThreshold)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TurnRedForOneSecond());
        }
    }

    IEnumerator TurnRedForOneSecond()
    {
        rockRenderer.material.color = Color.red;
        yield return new WaitForSeconds(1f);
        rockRenderer.material.color = originalColor;
    }
}
