using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] private Canvas[] exitCanvas;
    [SerializeField] private NPCInteract[] Quizes;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InteractNPC();
        InteractDoor();
        ExitCanvas();
    }

    void InteractNPC()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {   
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position,interactRange);
            foreach(Collider collider in colliderArray)
            {
                if(collider.TryGetComponent(out NPCInteract NPC))
                {
                    NPC.Interact();
                }
            }   
        }
    }

    void InteractDoor()
    {
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
    }

    void ExitCanvas()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (Canvas can in exitCanvas)
            {
                can.GetComponent<Canvas>().enabled = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            foreach (NPCInteract npc in Quizes)
            {
                if(!npc.GetComponent<NPCInteract>().Completed)
                {
                    npc.GetComponent<NPCInteract>().score = 0;

                    for (int i = 0; i < npc.GetComponent<NPCInteract>().Answered.Count; i++)
                    {
                        npc.GetComponent<NPCInteract>().QnA.Add(npc.GetComponent<NPCInteract>().Answered[i]);
                    }

                    npc.GetComponent<NPCInteract>().Answered = new List<QuestionsAndAnswers>();

                    npc.GetComponent<NPCInteract>().QuizPanel.SetActive(true);
                    npc.GetComponent<NPCInteract>().GoPanel.SetActive(false);
                    npc.GetComponent<NPCInteract>().Completed = false;
                }
            }
        }
    }
}
