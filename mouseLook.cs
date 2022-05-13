using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{


    public float xMoveThreshold = 1000.0f;
    public float yMoveThreshold = 1000.0f;

    //Y limit
    public float yMaxLimit = 45.0f;
    public float yMinLimit = -45.0f;
    float yRotCounter = 0.0f;

    //X limit
    public float xMaxLimit = 45.0f;
    public float xMinLimit = -10.0f;
    float xRotCounter = 0.0f;

    
    Transform player;

    void Start()
    {
        player = this.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get X value and limit it
        
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if (touch.position.x < Screen.width / 2)
                {
                    xRotCounter += (Input.GetAxis("Mouse X") * xMoveThreshold * Time.deltaTime) * 0.03f;
                    xRotCounter = Mathf.Clamp(xRotCounter, xMinLimit, xMaxLimit);

                    //Get Y value and limit it
                    yRotCounter += (Input.GetAxis("Mouse Y") * yMoveThreshold * Time.deltaTime) * 0.03f;
                    yRotCounter = Mathf.Clamp(yRotCounter, yMinLimit, yMaxLimit);
                    //xRotCounter = xRotCounter % 360;//Optional
                    player.localEulerAngles = new Vector3(-yRotCounter, +xRotCounter, 0);
                }
            }
        
    }

}
