using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoor : MonoBehaviour
{
    [SerializeField] Canvas keypad;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnabledKeypad()
    {
        keypad.GetComponent<Canvas>().enabled = true;
        Debug.Log("Started Keypad");
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<MouseView>().enabled = false; 
        Cursor.lockState = CursorLockMode.None;
    }

}
