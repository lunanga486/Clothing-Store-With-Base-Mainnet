using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowCanvasOnTouch : MonoBehaviour
{
    public GameObject ShirtBuyPanel; // Kéo thả Canvas vào đây từ Inspector

    private float lastTriggerTime = -Mathf.Infinity; // Lưu trữ thời gian lần cuối cùng sự kiện kích hoạt
    public float cooldownTime = 5f; // Thời gian chờ 5 giây

    private PlayerController playerController; // Biến lưu trữ PlayerController

    public GameObject itemBalancePanel;

    private void Start()
    {
        // Đảm bảo Canvas ban đầu ẩn đi
        if (ShirtBuyPanel != null)
        {
            ShirtBuyPanel.SetActive(false);
        }

        itemBalancePanel.SetActive(false);
    }

    // Phương thức này sẽ kích hoạt khi đối tượng va chạm với "Player"
    private void OnTriggerEnter(Collider other)
    {
        // Log khi bất kỳ đối tượng nào chạm vào collider này
        Debug.Log("Đã phát hiện va chạm.");

        // Kiểm tra nếu đối tượng va chạm có tag là "Player" và đủ thời gian chờ từ lần kích hoạt trước
        if (other.CompareTag("Player") && Time.time >= lastTriggerTime + cooldownTime)
        {
            Debug.Log("Va chạm với Player!");

            // Cập nhật thời gian kích hoạt cuối cùng
            lastTriggerTime = Time.time;

            // Hiển thị ShirtBuyPanel nếu nó không null
            if (ShirtBuyPanel != null)
            {
                ShirtBuyPanel.SetActive(true);
                Debug.Log("ShirtBuyPanel đã được hiển thị.");

                itemBalancePanel.SetActive(true);

                // Lưu tham chiếu đến PlayerController từ đối tượng người chơi
                playerController = other.GetComponent<PlayerController>();

                // Kiểm tra nếu PlayerController không null
                if (playerController != null)
                {
                    // Đặt moveSpeed và runSpeed về 0 để ngừng di chuyển người chơi
                    playerController.moveSpeed = 0f;
                    playerController.runSpeed = 0f;
                    Debug.Log("Tốc độ của Player đã được đặt về 0.");

                    // Mở khóa và hiển thị con trỏ chuột
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Debug.Log("Con trỏ chuột đã được mở khóa và hiển thị.");
                }
                else
                {
                    Debug.LogWarning("Không tìm thấy PlayerController trên đối tượng Player.");
                }
            }
            else
            {
                Debug.LogWarning("ShirtBuyPanel chưa được gán hoặc không tồn tại.");
            }
        }
    }

    public void BackToShop()
    {
        // Ẩn ShirtBuyPanel
        ShirtBuyPanel.SetActive(false);

        // Tìm đối tượng có Tag là "Player"
        GameObject playerObject = GameObject.FindWithTag("Player");

        Debug.Log("Player");

        if (playerObject != null)
        {
            // Lấy script PlayerController từ đối tượng
            PlayerController playerController = playerObject.GetComponent<PlayerController>();

            itemBalancePanel.SetActive(false);

            // Kiểm tra nếu PlayerController không null
            if (playerController != null)
            {
                // Khôi phục tốc độ của người chơi
                playerController.moveSpeed = 5f;
                playerController.runSpeed = 8f;
                Debug.Log("Tốc độ của Player đã được khôi phục.");

                // Khóa và ẩn con trỏ chuột
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Debug.Log("Con trỏ chuột đã được khóa và ẩn.");
            }
            else
            {
                Debug.LogWarning("Không tìm thấy PlayerController trên đối tượng Player.");
            }
        }
        else
        {
            Debug.LogWarning("Không tìm thấy đối tượng có Tag là 'Player'.");
        }
    }


}
