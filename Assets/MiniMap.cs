using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        if (player != null)
        {
            // Lấy vị trí hiện tại của MiniMap
            Vector3 newPos = transform.position;

            // Cập nhật chỉ tọa độ y của MiniMap để giữ nguyên vị trí theo trục y của player
            newPos.y = player.position.y;

            // Gán lại vị trí mới cho MiniMap
            transform.position = newPos;
        }
    }
}
