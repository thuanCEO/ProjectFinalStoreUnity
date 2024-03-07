using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealBar : MonoBehaviour
{
    [SerializeField]private Slider slider;
    public void UpdateEnemyHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue/ maxValue;
    }

}
