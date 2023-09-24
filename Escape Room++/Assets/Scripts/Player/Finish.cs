using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Finish")
        {
            FinishMap();
        }
    }

    void FinishMap()
    {
        int FinishIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(FinishIndex);
    }
}
