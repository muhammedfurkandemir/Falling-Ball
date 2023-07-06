
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xSpeed;
    public float limitx;
    public Vector3 startPosition;
    private bool setStarted=false;
    void Update()
    {
        setStartPosition();
        SwipeCheck();
    }
    void SwipeCheck()
    {
        if (GameManager.gameOver == false && GameManager.gameStarted==true)
        {
            float newX = 0;
            float touchXDelta = 0;
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                touchXDelta = Input.GetTouch(0).deltaPosition.x;
            }
            if (Input.GetMouseButton(0))
            {
                touchXDelta = Input.GetAxis("Mouse X");
                //touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
            }
            newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
            newX = Mathf.Clamp(newX, -limitx, limitx);


            Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
        
    }
    void setStartPosition()
    {
        if (Input.GetMouseButtonDown(0) && !setStarted)
        {
            Debug.Log("Butona Basıldı!");
            this.transform.position = startPosition;
            setStarted = true;
        }        
    }
}
