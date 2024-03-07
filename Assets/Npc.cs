using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public DialogueTrigger trigger;
    private bool canStartDialogue = false;
    private bool dialogueStarted = false; // Bi?n ki?m tra ?  b?t ??u cu?c tr  chuy?n

    private void Update()
    {
        if (canStartDialogue && Input.GetKeyDown(KeyCode.Z) && !dialogueStarted)
        {
            trigger.StartDialogue();
            dialogueStarted = true; // ??t bi?n n y th nh true ?? ? nh d?u r?ng cu?c tr  chuy?n ?  ???c b?t ??u
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canStartDialogue = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canStartDialogue = false;
            trigger.EndDialogue(); // ??m b?o k?t th c cu?c tr  chuy?n khi nh n v?t r?i kh?i NPC
            dialogueStarted = false; // ??t l?i bi?n dialogueStarted th nh false khi cu?c tr  chuy?n k?t th c
        }
    }
}
