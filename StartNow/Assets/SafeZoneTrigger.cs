using UnityEngine;

public class SafeZoneTrigger : MonoBehaviour
{
    // Hàm này tự động chạy khi có ai đó bước VÀO vùng Trigger
    void OnTriggerEnter(Collider other)
    {
        // Kiểm tra xem thẻ tên (Tag) có phải là người chơi không
        if (other.CompareTag("Player"))
        {
            Debug.Log(">>> AN TOÀN! (Ma đã bị mù)");
            // Sau này: Hồi máu, tắt nhạc rùng rợn...
        }
    }

    // Hàm này tự động chạy khi bước RA KHỎI vùng Trigger
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("<<< NGUY HIỂM! (Đã bước vào bóng tối)");
            // Sau này: Ma bắt đầu đuổi, bật nhạc dồn dập...
        }
    }
}