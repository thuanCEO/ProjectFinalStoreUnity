using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillL : MonoBehaviour
{
     public Image imageCooldown;
     public float cooldown = 5;
     private bool isCooldown = false;

     void Update()
     {
        
         if (Input.GetKeyDown(KeyCode.L) && !isCooldown)
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
