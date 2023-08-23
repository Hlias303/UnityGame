using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Serialize its coMmand that you can chage the values on INSPECTOR!!
    //[SerializeField]float xValue = 0;
    [SerializeField]float yValue = 0.01f;
    //[SerializeField]float zValue = 0;
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
        Debug.Log("Wolcome to the game");
        Debug.Log("Move your player with WASD or arrow keys");
        Debug.Log("Dont hit the walls");
    }

    void MovePlayer(){
        //transform.Translate(xValue,yValue,zValue); //we put f after the value to show that it is a float
        //Timedelta sychronizes with frame
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue,0,zValue);
        //with getaxis we can have control of input manager movements
    }

}
