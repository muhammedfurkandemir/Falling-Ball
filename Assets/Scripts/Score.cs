using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int highScore;
    Text scoreText;
    public Text panelScoreText;
    public Text panelHighScoreText;
    public GameObject New;
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        highScore = PlayerPrefs.GetInt("highScore");
        panelScoreText.text = "Score : " + score.ToString();
        panelHighScoreText.text = "Best   : " + highScore.ToString();
    }

    
    void Update()
    {
        
    }

    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        panelScoreText.text = "Score : " + score.ToString();
        if (score>highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
            panelHighScoreText.text = "Best   : " + highScore.ToString();
            New.SetActive(true);
        }
    }
}
