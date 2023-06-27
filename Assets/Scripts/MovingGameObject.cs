using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGameObject : MonoBehaviour
{
    public float borderX;
    public float movingSpeedX;

    private bool isArrivedRightBorder=false;
    private bool isArrivedLeftBorder=true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isArrivedRightBorder && isArrivedLeftBorder)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        
        if (transform.position.x >= borderX)
        {
            isArrivedRightBorder = true;
            isArrivedLeftBorder = false;
        }
        if (!isArrivedLeftBorder && isArrivedRightBorder)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        if (transform.position.x <= -borderX)
        {
            isArrivedLeftBorder = true;
            isArrivedRightBorder = false;
        }

    }
}
