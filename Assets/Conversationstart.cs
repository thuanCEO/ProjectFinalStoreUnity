using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversationstart : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;

    private bool playerInsideCollider = false; 

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInsideCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInsideCollider = false;
            ConversationManager.Instance.EndConversation(); 
        }
    }

    private void Update()
    {

        if (playerInsideCollider && Input.GetKeyDown(KeyCode.Z))
        {
            ConversationManager.Instance.StartConversation(myConversation); 
        }
    }
}