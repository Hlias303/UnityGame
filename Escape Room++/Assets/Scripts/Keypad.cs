using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{

    [SerializeField] private Text Ans;

    [SerializeField] private Animator Door;

    [SerializeField] private Canvas canvasKey;

    [SerializeField] private GameObject player;

    [SerializeField] string OpenName = "DoorOpenBig";

    private string Answer = "352185";


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
            OpenDoor();
            //Invoke("OpenDoor",2);
            Invoke("DisableKeypad",2);

        }
        else
        {
            Ans.text = "Incorrect!";
            Ans.color = Color.red;
        }
    }

    void OpenDoor()
    {
        Door.Play(OpenName,0,0.0f);
    }

    public void ResetKeypad()
    {
        if (Ans.text != "")
        {
            Ans.text = "";
        }
    }
}