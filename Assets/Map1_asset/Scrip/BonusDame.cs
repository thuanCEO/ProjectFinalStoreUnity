using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDame : MonoBehaviour
{
    private AttackArea attackAreaScript;
    private bool isBoosted = false;
    private int bonusDamage = 15;

    void Start()
    {
        attackAreaScript = GetComponent<AttackArea>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && !isBoosted)
        {
            StartCoroutine(BoostDamageForDuration(10f));
        }
    }

    IEnumerator BoostDamageForDuration(float duration)
    {
        isBoosted = true;

        int previousDamage = attackAreaScript.GetDamage();

        attackAreaScript.SetDamage(previousDamage + bonusDamage);

      

        yield return new WaitForSeconds(duration);

        attackAreaScript.SetDamage(previousDamage);
        isBoosted = false;

     
    }
}
