using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject target;

    [Header("Camera")]
    public float distance = 10f;
    public float mouseSensitivity = 3f;
    public float minDistance = 3f;
    public float maxDistance = 20f;

    [Header("Vertical Rotation")]
    public float minPitch = -30f;
    public float maxPitch = 60f;

    private float yaw = 0f;
    private float pitch = 20f;

    void Update()
    {
        if (target == null || target.active == false)
            return;

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * 5f;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }

    void LateUpdate()
    {
        if (target == null || target.active == false)
            return;

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        Vector3 offset = rotation * new Vector3(0f, 0f, -distance);

        transform.position = target.transform.position + offset;

        transform.LookAt(target.transform);
    }
}
