using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{

    public bool isCorrect = false;
    public GameObject question;
    public Button restartButton;
    public GameObject death;
    public QuizManager quizManager;
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.correct();

            question.SetActive(false);
            death.SetActive(true);
            restartButton.gameObject.SetActive(true);

        }
 
    }


}
