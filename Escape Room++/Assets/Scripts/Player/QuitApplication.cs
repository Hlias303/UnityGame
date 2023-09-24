using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitApplication : MonoBehaviour
{
   // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("You pressed escape");
            int FinishIndex = SceneManager.GetActiveScene().buildIndex;
            FinishIndex = 0;
            SceneManager.LoadScene(FinishIndex);
        }
    }
}
