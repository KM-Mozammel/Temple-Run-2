using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(
            transform.position.x, 
            transform.position.y, 
            playerTransform.position.z + offset.z
        );
        transform.position = newPosition;
    }
}