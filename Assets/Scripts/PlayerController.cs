using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xSpeed;
    public float limitx;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwipeCheck();

    }
    void SwipeCheck()
    {
        float newX = 0;
        float touchXDelta = 0;
        if (Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }
        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitx, limitx);


        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
