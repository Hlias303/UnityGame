using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoor : MonoBehaviour
{
    [SerializeField] public Canvas keypad;
    [SerializeField] GameObject player;
    
    public void EnabledKeypad()
    {
        Debug.Log("Started Keypad");
        keypad.GetComponent<Canvas>().enabled = true;
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<MouseView>().enabled = false; 
        Cursor.lockState = CursorLockMode.None;
    }

    public void DisableKeypad()
    {
        Debug.Log("Closed Keypad");
        keypad.GetComponent<Canvas>().enabled = false;
        player.GetComponent<Movement>().enabled = true;
        player.GetComponent<MouseView>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

}