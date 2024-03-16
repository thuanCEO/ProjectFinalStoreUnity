using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillI : MonoBehaviour
{
    // Start is called before the first frame update
    public Image imageCooldown;
    public float cooldown = 5;
    private bool isCooldown = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I) && !isCooldown)
        {
            isCooldown = true;
            imageCooldown.fillAmount = 1;
        }
        if (Input.GetKeyDown(KeyCode.I) && !isCooldown)
        {
            isCooldown = true;
            imageCooldown.fillAmount = 1;
        }

        if (isCooldown)
        {

            imageCooldown.fillAmount -= 1 / cooldown * Time.deltaTime;


            if (imageCooldown.fillAmount <= 0)
            {
                isCooldown = false;
            }
        }
    }
}
