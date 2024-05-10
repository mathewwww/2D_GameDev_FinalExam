using UnityEngine;

public class AutoMoveLeft : MonoBehaviour
{
    public float moveSpeed = 5f; 

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}
