using UnityEngine;

public class Billboard : MonoBehaviour
{
    [Header("Billboarding Settings")]
    public Camera targetCamera;
    public bool billboardOnStart = true;
    public bool lockYAxis = false;

    [Header("Rotation Offset (Degrees)")]
    public Vector3 rotationOffset = Vector3.zero;

    void Start()
    {
        if (targetCamera == null && billboardOnStart)
        {
            targetCamera = Camera.main;
        }
    }

    void LateUpdate()
    {
        if (targetCamera == null) return;

        Vector3 directionToCamera = targetCamera.transform.position - transform.position;

        if (lockYAxis)
        {
            directionToCamera.y = 0f;
        }

        // Face the camera
        Quaternion targetRotation = Quaternion.LookRotation(-directionToCamera.normalized);

        // Apply rotation offset
        targetRotation *= Quaternion.Euler(rotationOffset);

        transform.rotation = targetRotation;
    }
}
