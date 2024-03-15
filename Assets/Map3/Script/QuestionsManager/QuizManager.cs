using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{

    public GameObject panelToShow;
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    
    public Text QuestionTxt;

    private void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
    void SetAnswers()
    {
        
        int numAnswers = QnA[currentQuestion].Answers.Length;
        int numOptions = Mathf.Min(options.Length, numAnswers);

        for (int i = 0; i < numOptions; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
  
    void generateQuestion()
    {
       
        if (QnA.Count == 0)
        {
            Debug.Log("List question");
            // Deactivate object Panel
            panelToShow.SetActive(false);
            return;
        }

     
        currentQuestion = Random.Range(0, QnA.Count);

        
        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswers();
    }
}
