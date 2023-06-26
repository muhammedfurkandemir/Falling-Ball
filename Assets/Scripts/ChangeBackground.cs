using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public Color32[] backgroundColors;
    public float changingTime;
    public Camera _cam;
    int index = 0;
    float timer;
    void Start()
    {
         _cam = this.GetComponent<Camera>();   
    }


    void Update()
    {
        if (GameManager.gameStarted == true && GameManager.gameOver == false)
        {
            _cam.backgroundColor = Color.Lerp(_cam.backgroundColor, backgroundColors[index], 3f);
            timer += Time.deltaTime;
            if (timer > changingTime)
            {
                index++;
                if (backgroundColors.Length - 1 == index)
                    index = 0;
                timer = 0;
            }
        }
        
    }
}
