using UnityEngine;

public class SpinningObject : MonoBehaviour
{
    [Header("Rotation Settings")]
[Tooltip("Axis of rotation in local space")]
public Vector3 rotationAxis = Vector3.up;

[Tooltip("Rotation speed in degrees per second")]
public float rotationSpeed = 10f;

[Header("Axis Tilt")]
[Tooltip("Tilt angle in degrees")]
public float tiltAngle = 0f;

[Tooltip("Optional pivot for axial tilt (set manually or leave empty)")]
public Transform tiltPivot;

[Header("Moon Orbit Settings")]
[Tooltip("Optional moon object to orbit this body")]
public Transform moon;

[Tooltip("Pivot that controls the moon's orbit (set manually)")]
public Transform moonOrbitPivot;

[Tooltip("Distance of the moon from the orbit center")]
public float orbitRadius = 5f;

[Tooltip("Moon orbit speed in degrees/second")]
public float orbitSpeed = 15f;

[Tooltip("Moon orbit tilt angle (degrees)")]
public float orbitTilt = 5f;

[Header("Moon Rotation Settings")]
[Tooltip("Moon rotation speed in degrees/second")]
public float moonRotationSpeed = 10f;

[Tooltip("Axis of moon's rotation in local space")]
public Vector3 moonRotationAxis = Vector3.up;

void Start()
{
    // Setup moon orbit pivot rotation if assigned and tilt is desired
    if (moonOrbitPivot != null)
    {
        moonOrbitPivot.localRotation = Quaternion.Euler(orbitTilt, 0f, 0f);

        // Reposition moon at radius if it's not placed already
        if (moon != null)
            moon.localPosition = new Vector3(orbitRadius, 0f, 0f);
    }
}

void Update()
{
    // Planet spin
    if (tiltPivot != null)
    {
        tiltPivot.Rotate(rotationAxis.normalized, rotationSpeed * Time.deltaTime, Space.Self);
    }
    else
    {
        transform.Rotate(rotationAxis.normalized, rotationSpeed * Time.deltaTime, Space.Self);
    }

    // Moon orbit
    if (moonOrbitPivot != null)
    {
        moonOrbitPivot.Rotate(Vector3.up, orbitSpeed * Time.deltaTime, Space.Self);
    }

    // Moon axial spin
    if (moon != null)
    {
        moon.Rotate(moonRotationAxis.normalized, moonRotationSpeed * Time.deltaTime, Space.Self);
    }
}
}
