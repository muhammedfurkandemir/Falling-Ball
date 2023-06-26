using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    
    void Update()
    {
        IncrementScore();
    }

    void IncrementScore()
    {
        scoreText.text = GameManager.score.ToString();
    }
}
