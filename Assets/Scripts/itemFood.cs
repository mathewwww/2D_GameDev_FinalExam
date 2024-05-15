using UnityEngine;

public class ItemFood : MonoBehaviour
{
    public float itemMovementSpeed = 5f;
    public float destroyThreshold = -15f;

    void Update()
    {

        transform.Translate(Vector3.left * itemMovementSpeed * Time.deltaTime);


        if (transform.position.x < destroyThreshold)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
