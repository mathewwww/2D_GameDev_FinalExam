using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RockCollision : MonoBehaviour
{
    public float obstacleMovementSpeed = 5f;
    public float destroyThreshold = -15f;

    private Color originalColor;
    private Renderer rockRenderer;

    void Update()
    {
        transform.Translate(Vector3.left * obstacleMovementSpeed * Time.deltaTime);

        if (transform.position.x < destroyThreshold)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rockRenderer = GetComponent<Renderer>();
        originalColor = rockRenderer.material.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
