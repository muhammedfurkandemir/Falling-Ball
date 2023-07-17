
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public Camera _cam;
    public Color[] colors;
    private int currentColorIndex = 0;
    private int targetColorIndex = 1;
    private float targetPoint;
    private float timer;
    private bool change =false;
    public float time;
    public float changeColorTime;
    
    void Start()
    {
         _cam = this.GetComponent<Camera>();
        
    }

    void Transitition()
    {
        if (GameManager.gameStarted == true && GameManager.gameOver == false)
        {
            timer += Time.deltaTime;            
            if (timer>=changeColorTime)
            {
                change = !change;
                timer = 0;
            }
            if (change)
            {
                targetPoint += Time.deltaTime / time;
                _cam.backgroundColor = Color.Lerp(colors[currentColorIndex], colors[targetColorIndex], targetPoint);
            }            
            if (targetPoint>=1)
            {
                targetPoint = 0;
                currentColorIndex = targetColorIndex;
                targetColorIndex++;
                if (targetColorIndex == colors.Length)
                    targetColorIndex = 0;
            }
        }
    }
    void Update()
    {

        Transitition();
    }
}
