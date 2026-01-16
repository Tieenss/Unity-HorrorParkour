using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    public Light flashlightSource; // Tham chiếu đến cái đèn
    public bool isLightOn = true; // Trạng thái đèn (đang bật hay tắt)
    // (Thầy đặt tên biến vui vẻ chút, em có thể đặt là isLightOn)

    void Start()
    {
        // Đảm bảo lúc bắt đầu game đèn luôn bật
        flashlightSource.enabled = true;
    }

    void Update()
    {
        // Nếu nhấn phím F
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Đảo ngược trạng thái (Đang bật -> tắt, Đang tắt -> bật)
            isLightOn = !isLightOn;

            // Áp dụng vào cái đèn thật
            flashlightSource.enabled = isLightOn;

            // (Nâng cao sau này: Thêm tiếng cạch cạch khi bật tắt ở đây)
        }
    }
}