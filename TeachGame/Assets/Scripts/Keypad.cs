using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{

    public Canvas interactCanvas;
    [SerializeField] private Text Ans;
    [SerializeField] private Animator Door;
    [SerializeField] string OpenName = "DoorOpen";
    [SerializeField]int Time_to_wait = 3;
    private string Answer = "123";

    public void Number(int number)
    {
        if (Ans.text == "Incorrect!")
        {
            Ans.color = Color.black;
            Ans.text = "";
            Ans.text += number.ToString();
        }
        else if (Ans.text == "Correct!")
        {
            Debug.Log("Correct");
        }
        else
        {
            Ans.text += number.ToString();
        }
    }

    public void Execute()
    {
        if (Ans.text == Answer)
        {
            Ans.text = "Correct!";
            Ans.color = Color.green;
            if(Time.time > Time_to_wait )
            {
                Door.Play(OpenName,0,0.0f);
            }
            interactCanvas.GetComponent<Canvas>().enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Ans.text = "Incorrect!";
            Ans.color = Color.red;
        }
    }

    public void StartKeypad()
    {
        Debug.Log("Started Keypad");
        interactCanvas.GetComponent<Canvas>().enabled = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
