using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalSpeed = 5f;
    public float smoothTime = 0.1f; 
    public float[] lanePositions;

    private int currentLane = 3; 
    private Vector3 targetPosition; 
    private Vector3 velocity = Vector3.zero; 

    void Start()
    {
     
        currentLane = Mathf.Clamp(currentLane, 0, lanePositions.Length - 1);

        targetPosition = new Vector3(transform.position.x, lanePositions[currentLane], transform.position.z);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (currentLane < lanePositions.Length - 1)
            {
                currentLane++;
                UpdateTargetPosition();
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (currentLane > 0)
            {
                currentLane--;
                UpdateTargetPosition();     
            }
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveHorizontal * horizontalSpeed * Time.deltaTime);

        Vector3 currentPosition = transform.position;
        currentPosition.y = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime).y;
        transform.position = currentPosition;
    }

    void UpdateTargetPosition()
    {
        targetPosition = new Vector3(transform.position.x, lanePositions[currentLane], transform.position.z);
    }
}
