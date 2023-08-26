using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class NPCInteract : MonoBehaviour
{
    public Canvas interactCanvas;
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public Text QuestionTxt;

    public void generateQuestion()
    {
        currentQuestion = Random.Range(0,QnA.Count);

        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswers();
    }

    void SetAnswers()
    {
        for(int i = 0 ; i <options.Length; i++ )
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text =QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer ==i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            } 
        }
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion(); 
    }
    public void Interact()
    {
        Debug.Log("Interact");
        interactCanvas.GetComponent<Canvas>().enabled = true;
        generateQuestion();
    }
}
