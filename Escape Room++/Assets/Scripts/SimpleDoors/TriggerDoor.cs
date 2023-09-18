using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] Animator myDoor = null;

    [SerializeField] bool openTrigger = false;
    [SerializeField] bool closeTrigger = false;
    [SerializeField] string OpenName = "DoorOpen";
    [SerializeField] string CloseName = "CloceDoor";
    AudioSource AudioDoor;

    // Start is called before the first frame update

    void Start()
    {
        AudioDoor = GetComponent<AudioSource>();
        AudioDoor.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
          
        if (other.CompareTag("Player"))
        {
            AudioDoor.enabled = true;
            if(openTrigger)
            {
                
                AudioDoor.Play();
                myDoor.Play(OpenName,0,0.0f);
            }
            if(closeTrigger)
            {
                AudioDoor.Play();
                //collider.enabled = true;
                myDoor.Play(CloseName,0,0.0f);
                //gameObject.SetActive(false);
            }
        }
    }
}
