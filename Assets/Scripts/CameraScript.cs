using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float overshootAmount = 1.5f;
    public Vector2 overshootXLimit = new Vector2(-Mathf.Infinity, Mathf.Infinity);
    public Vector2 overshootYLimit = new Vector2(-Mathf.Infinity, Mathf.Infinity);

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate target position with overshoot
            Vector3 targetPosition = target.position + (target.position - transform.position) * overshootAmount;

            // Apply overshoot limits
            targetPosition.x = Mathf.Clamp(targetPosition.x, overshootXLimit.x, overshootXLimit.y);
            targetPosition.y = Mathf.Clamp(targetPosition.y, overshootYLimit.x, overshootYLimit.y);

            // Preserve the z-axis position of the camera
            targetPosition.z = transform.position.z;

            // Smoothly move the camera towards the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
        }
    }
}
