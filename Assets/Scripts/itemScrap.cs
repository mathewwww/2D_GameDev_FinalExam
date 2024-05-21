
using UnityEngine;
using System.Collections;

public class ItemScrap : MonoBehaviour
{
    public float itemMovementSpeed = 5f; 
    public float destroyThreshold = -15f;

    private float[] speedIncreaseIntervals = { 20f, 40f, 60f }; 
    private float[] speedTiers = { 7f, 8f, 11f }; 


    void Update()
    {
        transform.Translate(Vector3.left * itemMovementSpeed * Time.deltaTime);

        for (int i = 0; i < speedIncreaseIntervals.Length; i++)
        {
            if (Time.time >= speedIncreaseIntervals[i] && itemMovementSpeed < speedTiers[i])
            {
                itemMovementSpeed = speedTiers[i];
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
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
