using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector2 offset = new Vector2(0f, 0f);
    public float smoothSpeed = 0.125f;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    private void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        float clampedX = Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x);
        float clampedY = Mathf.Clamp(transform.position.y, minPosition.y, maxPosition.y);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
