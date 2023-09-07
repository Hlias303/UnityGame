﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public NPCInteract quizManager;
    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
         {
            Debug.Log("Wrong answer");
            quizManager.Wrong();
        }

    }
}
