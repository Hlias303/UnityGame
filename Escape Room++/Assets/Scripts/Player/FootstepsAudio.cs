using UnityEngine;

public class FootstepsAudio : MonoBehaviour
{
     public AudioSource footstepsAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            footstepsAudio.enabled = true;
        }
        else
        {
            footstepsAudio.enabled = false;
        }
    }
}
