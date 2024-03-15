using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public int SceneManagementIndex;
    private GameObject player; // Tham chiếu đến đối tượng người chơi
    private Vector3 savedPlayerPosition; // Vị trí của người chơi trước khi chuyển cảnh
    private bool hasPlayerMoved = false; // Kiểm tra xem người chơi đã chuyển cảnh hay chưa

    // Vị trí cố định mà người chơi sẽ được đặt lại khi chuyển cảnh
    public Vector3 fixedPlayerPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasPlayerMoved)
        {
            player = other.gameObject; // Gán tham chiếu đến người chơi
            savedPlayerPosition = player.transform.position; // Lưu vị trí của người chơi

            // Vô hiệu hóa người chơi
            player.SetActive(false);

            // Set cờ báo hiệu người chơi đã chuyển cảnh
            hasPlayerMoved = true;

            // Load cảnh mới
            SceneManager.LoadScene(SceneManagementIndex, LoadSceneMode.Single);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == SceneManagementIndex && player != null)
        {
            // Kích hoạt lại người chơi
            player.SetActive(true);

            // Gán lại vị trí cho người chơi (sử dụng vị trí cố định)
            player.transform.position = fixedPlayerPosition;

            // Đặt lại cờ báo hiệu người chơi đã chuyển cảnh
            hasPlayerMoved = false;
        }
    }
}
