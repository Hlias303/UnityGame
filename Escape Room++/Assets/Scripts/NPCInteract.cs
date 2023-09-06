using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCInteract : MonoBehaviour
{
    public Canvas interactCanvas;
    public List<QuestionsAndAnswers> QnA;
    public List<QuestionsAndAnswers> Answered;
    public GameObject[] options;
    public int currentQuestion;
    public Text QuestionTxt;
    public Text ScoreTxT;
    public Text PassTxT; 

    public int TotalQuestions = 0;
    public int score;
    public GameObject QuizPanel;
    public GameObject GoPanel;

    public bool Completed = false;

    public void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0,QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of questions");
            GameOver();
        }

    }

    public void GameOver()
    {
        if (score >= TotalQuestions / 2)
        {
            QuizPanel.SetActive(false);
            GoPanel.SetActive(true);
            ScoreTxT.text = score.ToString() + "/10";
            PassTxT.enabled = true;
        }
        else
        {
            QuizPanel.SetActive(false);
            GoPanel.SetActive(true);
            ScoreTxT.text = score.ToString() + "/10";
            PassTxT.enabled = false;
        }
        Completed = true;
    }

    public void Retry()
    {
        score = 0;

        for (int i = 0; i < Answered.Count; i++) 
        {
            QnA.Add(Answered[i]);
        }

        Answered = new List<QuestionsAndAnswers>();

        QuizPanel.SetActive(true);
        GoPanel.SetActive(false);
        Completed = false;
    }

    public void Exit()
    {
        if (Completed)
        {
            interactCanvas.GetComponent<Canvas>().enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void SetAnswers()
    {
        for(int i = 0 ; i < options.Length; i++ )
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            } 
        }
    }

    public void correct()
    {
        score += 1;
        Answered.Add(QnA[currentQuestion]);
        QnA.RemoveAt(currentQuestion);
        generateQuestion(); 
    }

    public void Wrong()
    {
        Answered.Add(QnA[currentQuestion]);
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
    public void Interact()
    {
        Debug.Log("Interact");
        StartPanel();
    }

    void StartPanel()
    {
        interactCanvas.GetComponent<Canvas>().enabled = true;
        Cursor.lockState = CursorLockMode.None;
        TotalQuestions = QnA.Count;
        QuizPanel.SetActive(true);
        GoPanel.SetActive(false);
        generateQuestion();
    }
}
