using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [Header("Target Tracking")]
    public Transform playerTransform;

    [Header("Horizontal Smooth Settings")]
    [Tooltip("If checked, the camera will follow the player left and right into lanes.")]
    public bool followX = true;
    
    [Tooltip("How fast the camera catches up to the player horizontally (Higher = faster).")]
    public float laneChangeSpeed = 5f;

    private Vector3 offset;

    void Start()
    {
        if (playerTransform != null)
        {
            // Calculate initial distance offset between camera and player
            Vector3 initialOffset = transform.position - playerTransform.position;

            // Adjust offset: 10% more behind (Z-axis) and 5% less upward (Y-axis)
            float adjustedY = initialOffset.y * 0.90f; 
            float adjustedZ = initialOffset.z * 1.20f; 

            offset = new Vector3(initialOffset.x, adjustedY, adjustedZ);
        }
    }

    void LateUpdate()
    {
        // Safety check: Prevent errors if player object is destroyed or missing
        if (playerTransform == null) return;

        // Calculate target X position based on follow toggle
        float targetX = followX ? (playerTransform.position.x + offset.x) : transform.position.x;
        
        // Smoothly slide along the X-axis using Lerp to eliminate sharp cuts
        float smoothedX = Mathf.Lerp(transform.position.x, targetX, Time.deltaTime * laneChangeSpeed);

        // Keep Y and Z locked cleanly to adjusted player progress
        float targetY = playerTransform.position.y + offset.y;
        float targetZ = playerTransform.position.z + offset.z;

        // Apply final calculated coordinates to the camera transform
        transform.position = new Vector3(smoothedX, targetY, targetZ);
    }
}