using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // The object (ball) the camera follows
    public float smoothSpeed = 0.125f;  // How smooth the camera movement is
    public Vector3 offset;  // Offset from the target (ball) to position the camera
    public float maxMovementDistance = 0.1f;  // Maximum distance the camera can move in each direction (in meters or units)

    private Vector3 lastPosition;

    void Start()
    {
        // Store the initial position of the camera
        lastPosition = transform.position;
    }

    void LateUpdate()
    {
        // Define the desired position with an offset
        Vector3 desiredPosition = target.position + offset;

        // Calculate the difference between the current and the desired position
        Vector3 difference = desiredPosition - transform.position;

        // Limit the movement of the camera to the maxMovementDistance in each direction
        difference = Vector3.ClampMagnitude(difference, maxMovementDistance);

        // Smoothly move the camera towards the new position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, transform.position + difference, smoothSpeed);

        // Apply the smoothed position
        transform.position = smoothedPosition;

        // Prevent rotation by keeping the camera's rotation the same
        transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Keeps the rotation fixed to 0
    }
}
