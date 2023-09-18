using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Canvas PauseCanvas;
    [SerializeField] private Keypad KeyPad;
    private bool inNpcInteraction = false;
    private bool inBigDoorInteraction = false;
    private bool isGamePaused = false;

    // Update is called once per frame
    void Update()
    {
        PauseGame();
        InteractNPC();
        InteractDoor();
    }

    void InteractNPC()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NPCInteract NPC))
            {
                // NPC interaction when the 'E' key is pressed
                if (Input.GetKeyDown(KeyCode.E))
                {
                    NPC.Interact();
                    inNpcInteraction = true;
                }
                // Exiting the NPC interaction when the 'Escape' key is pressed
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (NPC.interactCanvas.enabled && !NPC.Completed)
                    {
                        Cursor.lockState = CursorLockMode.Locked;
                        NPC.interactCanvas.enabled = false;
                        NPC.player.GetComponent<Movement>().enabled = true;
                        NPC.player.GetComponent<MouseView>().enabled = true;
                        NPC.score = 0;

                        for (int i = 0; i < NPC.Answered.Count; i++)
                        {
                            NPC.QnA.Add(NPC.Answered[i]);
                        }

                        NPC.Answered = new List<QuestionsAndAnswers>();
                        NPC.QuizPanel.SetActive(true);
                        NPC.GoPanel.SetActive(false);
                        NPC.Completed = false;
                        inNpcInteraction = false;
                    }
                }

                if (NPC.Completed && !NPC.interactCanvas.enabled) { inNpcInteraction = false; }

            }
        }
    }

    void InteractDoor()
    {

        Collider[] colliderArray = Physics.OverlapBox(transform.position, transform.localScale * 2);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out BigDoor bigDoor))  // Door interaction when 'E' key is pressed
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    bigDoor.EnabledKeypad();
                    inBigDoorInteraction = true;
                }
                else if (Input.GetKeyDown(KeyCode.Escape))  // Exiting keypad when 'Escape' key is pressed
                {
                    if (bigDoor.keypad.GetComponent<Canvas>().enabled)
                    {
                        bigDoor.DisableKeypad();
                        KeyPad.ResetKeypad();
                        inBigDoorInteraction = false;
                    }
                }
            }
        } 
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Debug.Log("Trying to Pause Game");
            if (Player.GetComponent<MouseView>().introduction && !inNpcInteraction && !inBigDoorInteraction && !isGamePaused)
            {
                isGamePaused = true;
                PauseCanvas.enabled = true;
                Player.GetComponent<Movement>().enabled = false;
                Player.GetComponent<MouseView>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Game Paused");
            }
            else if (isGamePaused)
            {
                isGamePaused = false;
                PauseCanvas.enabled = false;
                Player.GetComponent<Movement>().enabled = true;
                Player.GetComponent<MouseView>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Debug.Log("Game Resumed");
            }
        }
    }

    public void ResumeBtn()
    {
        isGamePaused = false;
        PauseCanvas.enabled = false;
        Player.GetComponent<Movement>().enabled = true;
        Player.GetComponent<MouseView>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Game Resumed");
    }

}
