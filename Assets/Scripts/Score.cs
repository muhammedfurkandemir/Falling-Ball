
using Unity.VisualScripting;
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
        panelScoreText.text = "Score: " + score.ToString();
        panelHighScoreText.text = "Best: " + highScore.ToString();        
    }

    public void Scored()
    {
        score++;        
        scoreText.text = score.ToString();
        panelScoreText.text = "Score: " + score.ToString();
        CheckHighScore();
    }
    public void AddScored(int addedScore)
    {
        score += addedScore;
        scoreText.text = score.ToString();
        panelScoreText.text = "Score: " + score.ToString();
        CheckHighScore();
    }
    void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
            panelHighScoreText.text = "Best: " + highScore.ToString();
            New.SetActive(true);
        }
    }
    public int GetScore()
    {
        return score;
    }
}
