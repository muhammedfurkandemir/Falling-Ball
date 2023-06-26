using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static bool gameStarted;
    public static bool gameOver;
    public GameObject gameStartImage;
    public GameObject gameOverPanel;
    public GameObject score;
  

    public Rigidbody _rigidbody;
    void Start()
    {
        gameStarted = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)||Input.touchCount>0)
        {
            GameHasStarted();
        }
        
    }
    public void GameOver()
    {
        gameOver = true;
        gameStarted = true;
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;
        score.SetActive(false);
        gameOverPanel.SetActive(true);
        gameStarted = false;

    }
    public void GameHasStarted()
    {
        gameStarted = true;
        _rigidbody.useGravity = true;
        gameStartImage.SetActive(false);
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}
