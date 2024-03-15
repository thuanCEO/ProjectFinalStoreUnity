using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public Image imageCooldown;
    public float cooldown = 5;
    private bool isCooldown = false;

     void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.J) && !isCooldown)
        {
            isCooldown = true;
            imageCooldown.fillAmount = 1; 
        }

        
        if (isCooldown)
        {
            // Giảm fill amount của hình ảnh cooldown theo thời gian
            imageCooldown.fillAmount -= 1 / cooldown * Time.deltaTime;

            // Kiểm tra xem thời gian cooldown đã kết thúc chưa
            if (imageCooldown.fillAmount <= 0)
            {
                isCooldown = false; // Đánh dấu kết thúc cooldown
            }
        }
    }
}
