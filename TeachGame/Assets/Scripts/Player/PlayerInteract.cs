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
      
    }

    void InteractNpc()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {   
            //float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapBox(transform.position,transform.localScale *2);
            foreach(Collider collider in colliderArray)
            {
                if(collider.TryGetComponent(out NPCInteract NPC))
                {
                    NPC.Interact();
                }
            }   
        }
    }
}

