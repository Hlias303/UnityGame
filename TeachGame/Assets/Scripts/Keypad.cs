using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{

    //public Canvas interactCanvas;
    [SerializeField] private Text Ans;
    [SerializeField] private Animator Door;

    [SerializeField] private Canvas canvasKey;

    [SerializeField] private GameObject player;
    [SerializeField] string OpenName = "DoorOpen6";
    //[SerializeField]int Time_to_wait = 3;
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
            Invoke("OpenDoor",2);
            Invoke("DisableKeypad",2);

        }
        else
        {
            Ans.text = "Incorrect!";
            Ans.color = Color.red;
        }
    }

    void DisableKeypad()
    {
        canvasKey.GetComponent<Canvas>().enabled = false;
        player.GetComponent<Movement>().enabled = true;
        player.GetComponent<MouseView>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OpenDoor()
    {
        Door.Play(OpenName,0,0.0f);
    }


}
