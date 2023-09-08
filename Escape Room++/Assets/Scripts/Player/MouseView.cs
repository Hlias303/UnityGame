using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MouseView : MonoBehaviour
{
    private float x;
    private float y;
    public float sensitivity = -1f;
    private Vector3 rotate;
    public bool introduction = false;
    [SerializeField] private Canvas MainMenuCanvas;
    [SerializeField] private Canvas InfoCanvas;
    [SerializeField] private Canvas PauseMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuCanvas.GetComponent<Canvas>().enabled = true;
        InfoCanvas.GetComponent<Canvas>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if(introduction)
        {
            y = Input.GetAxis("Mouse X");
            x = Input.GetAxis("Mouse Y");
            rotate = new Vector3(x, y * sensitivity, 0);
            transform.eulerAngles = transform.eulerAngles - rotate;
        }
    }

    public void Started()
    {
        InfoCanvas.GetComponent<Canvas>().enabled = false;
        introduction = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MainStartBtn()
    {
        MainMenuCanvas.GetComponent<Canvas>().enabled = false;
        InfoCanvas.GetComponent<Canvas>().enabled = true;
    }

    public void MainExitBtn()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Resume()
    {
        PauseMenuCanvas.GetComponent<Canvas>().enabled = false;
    }
}
