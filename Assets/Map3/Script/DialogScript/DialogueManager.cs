using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    Message[] currenMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;
    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currenMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        Debug.Log("Started conversation! loaded messages: " + messages.Length);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f);
    }
    public void EndDialogue()
    {
        Debug.Log("Conversation ended!");
        backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
        isActive = false;
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currenMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }
    // Start is called before the first frame update

    public void NextMessage()
    {
        activeMessage++;
        if(activeMessage < currenMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation eneded!");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
        }
    }
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && isActive == true)
        {
            NextMessage();
        }
    }
}
