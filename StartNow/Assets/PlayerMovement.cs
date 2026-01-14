using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; // Tham chiếu đến bộ điều khiển
    public float speed = 6f;               // Tốc độ chạy
    public float mouseSensitivity = 400f;  // Tốc độ chuột (đã tăng lên)
    public float jumpHeight = 1.5f;        // Độ cao nhảy
    public float gravity = -9.81f;         // Trọng lực trái đất

    public Transform playerCamera;
    float xRotation = 0f;

    // Biến để lưu vận tốc rơi tự do
    Vector3 velocity;
    bool isGrounded; // Kiểm tra xem có đang đứng trên đất không

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Tự động tìm component CharacterController nếu quên kéo thả
        if (controller == null) controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // --- 1. XỬ LÝ NHÌN (GIỮ NGUYÊN) ---
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // --- 2. XỬ LÝ DI CHUYỂN (MỚI) ---
        // Kiểm tra xem nhân vật có đang chạm đất không
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Ép nhân vật dính xuống đất cho chắc
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Dùng controller.Move thay vì Translate để không đi xuyên tường
        controller.Move(move * speed * Time.deltaTime);

        // --- 3. XỬ LÝ NHẢY (MỚI) ---
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Công thức vật lý: Vận tốc = căn bậc 2 của (độ cao * -2 * trọng lực)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Áp dụng trọng lực (kéo nhân vật rơi xuống)
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}