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
    public GameObject[] options;
    public int currentQuestion;
    public Text QuestionTxt;
    public Text ScoreTxT; 

    public int TotalQuestions  = 0;
    public int score;
    public GameObject QuizPanel;
    public GameObject GoPanel;

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
            //interactCanvas.GetComponent<Canvas>().enabled = false;
            //Cursor.lockState = CursorLockMode.Locked; 
            GameOver();
        }

    }

    public void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxT.text = score.ToString();

    }

    public void Retry()
    {
        int RetryIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(RetryIndex);
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
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion(); 
    }

    public void Wrong()
    {
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
