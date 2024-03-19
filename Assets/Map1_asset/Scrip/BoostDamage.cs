using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostDamage : MonoBehaviour
{
    private AttackArea attackAreaScript;
    private bool isBoosted = false;

    void Start()
    {
        attackAreaScript = GetComponent<AttackArea>();
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.K) && !isBoosted)
    //    {
    //        StartCoroutine(BoostDamageForDuration(5f));
    //    }
    //}

    //IEnumerator BoostDamageForDuration(float duration)
    //{
    //    isBoosted = true;

    //    int previousDamage = attackAreaScript.GetDamage();

    //    attackAreaScript.SetDamage(previousDamage + 5);

    //    Debug.Log("Current Damage: " + attackAreaScript.GetDamage());

    //    yield return new WaitForSeconds(duration);

    //    attackAreaScript.SetDamage(previousDamage);
    //    isBoosted = false;

    //    Debug.Log("Damage Restored: " + attackAreaScript.GetDamage());
    //}
}
