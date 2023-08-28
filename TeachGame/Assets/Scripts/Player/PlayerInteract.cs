using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Start is called before the first frame update
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
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position,interactRange);
            foreach(Collider collider in colliderArray)
            {
                Debug.Log("Collided with door ");
                if(collider.TryGetComponent(out Keypad KP))
                {
                    KP.StartKeypad();
                }
            }   
        }
    }
}
