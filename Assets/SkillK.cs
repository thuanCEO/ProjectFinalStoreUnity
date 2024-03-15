using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
     public Image imageCooldown;
     public float cooldown = 5;
     private bool isCooldown = false;

     void Update()
     {
        
         if (Input.GetKeyDown(KeyCode.K) && !isCooldown)
        {
            isCooldown = true;
            imageCooldown.fillAmount = 1; 
     }
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


// [Header("Ability 1")]
//     public Image abilityImage1;
//     public float cooldown1 = 5;
//     private bool isCooldown1 = false;
//     public KeyCode ability1;

//     void Start()
//     {
//         abilityImage1.fillAmount = 0;
//     }

//     void Update()
//     {
//         Ability1();
//     }

//     void Ability1()
//     {
//         if (Input.GetKeyDown(ability1) && !isCooldown1)
//         {
//             isCooldown1 = true;
//             abilityImage1.fillAmount = 1;
//         }
        
//         if (isCooldown1)
//         {
//             abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
//             if (abilityImage1.fillAmount <= 0)
//             {
//                 abilityImage1.fillAmount = 0;
//                 isCooldown1 = false; 
//             }
//         }
//     }

}
