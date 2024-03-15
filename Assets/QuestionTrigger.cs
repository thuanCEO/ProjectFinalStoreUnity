using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTrigger : MonoBehaviour
{
    public GameObject panelToShow;
    private bool canActivatePanel = false;
    private int triggerCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && triggerCount == 0) // Ki?m tra triggerCount ?? ch? k�ch ho?t l?n ??u ti�n
        {
            canActivatePanel = true;
            triggerCount++; // T?ng triggerCount sau khi k�ch ho?t l?n ??u
        }
    }

    private void Update()
    {
        if (canActivatePanel && Input.GetKeyDown(KeyCode.Z))
        {
            panelToShow.SetActive(true);
            canActivatePanel = false;
        }
    }
}
