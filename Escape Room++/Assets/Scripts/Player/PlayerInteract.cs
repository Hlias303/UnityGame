using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] private NPCInteract[] Quizes;
    [SerializeField] private BigDoor bd;
    [SerializeField] private Keypad kp;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InteractNPC();
        InteractDoor();
    }

    void InteractNPC()
    {
        // NPC interaction when the 'E' key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {   
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position,interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteract NPC))
                {
                    NPC.Interact();
                }
            }
        }

        // Exiting the NPC interaction when the 'Escape' key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteract NPC))
                {
                    if (!NPC.GetComponent<NPCInteract>().Completed)
                    {
                        NPC.interactCanvas.enabled = false;
                        Cursor.lockState = CursorLockMode.Locked;
                        NPC.player.GetComponent<Movement>().enabled = true;
                        NPC.player.GetComponent<MouseView>().enabled = true;
                        NPC.GetComponent<NPCInteract>().score = 0;

                        for (int i = 0; i < NPC.GetComponent<NPCInteract>().Answered.Count; i++)
                        {
                            NPC.GetComponent<NPCInteract>().QnA.Add(NPC.GetComponent<NPCInteract>().Answered[i]);
                        }

                        NPC.GetComponent<NPCInteract>().Answered = new List<QuestionsAndAnswers>();

                        NPC.GetComponent<NPCInteract>().QuizPanel.SetActive(true);
                        NPC.GetComponent<NPCInteract>().GoPanel.SetActive(false);
                        NPC.GetComponent<NPCInteract>().Completed = false;
                    }
                }
            }
        }
    }

    void InteractDoor()
    {
        // Door interaction when 'E' key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {   
            Collider[] colliderArray = Physics.OverlapBox(transform.position,transform.localScale*2);
            foreach(Collider collider in colliderArray)
            {
                if(collider.TryGetComponent(out BigDoor bd))
                {
                    bd.EnabledKeypad();
                }
            }   
        }

        // Exiting keypad when 'Escape' key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Collider[] colliderArray = Physics.OverlapBox(transform.position, transform.localScale * 2);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out BigDoor bd))
                {
                    if (bd.keypad.GetComponent<Canvas>().enabled == true)
                    {
                        bd.DisableKeypad();
                        kp.ResetKeypad();
                    }
                }
            }
        }
    }

}
