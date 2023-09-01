using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]float yValue = 0.01f;
    [SerializeField]float moveSpeed = 2; // MoveSpeed for the input of movement 
     

    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void PrintInstructions(){
        Debug.Log("Welcome to the game");
        Debug.Log("Move your player with WASD or arrow keys");
    }

    void MovePlayer(){
        //Timedelta sychronizes with frame
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue,0,zValue);
        //with getaxis we can have control of input manager movements
    }

}
