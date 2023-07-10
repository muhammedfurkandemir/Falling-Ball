
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static bool gameStarted;
    public static bool gameOver;
    public GameObject gameStartImage;
    public GameObject gameOverPanel;
    public GameObject score;
    public GameObject startGround;
    public GameObject pausePanel;
    public GameObject pauseBtn;
    public GameObject addScore;

    public AudioSource btnSound;

    public Rigidbody _rigidbody;
    void Start()
    {
        gameStarted = false;
        gameOver = false;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)||Input.touchCount>0&&gameOver==false)
        {
            GameHasStarted();
        }
        
    }
    public void GameOver()
    {
        gameOver = true;
        gameStarted = true;
        pauseBtn.SetActive(false);
        addScore.SetActive(false);
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
        startGround.SetActive(true);
        pauseBtn.SetActive(true);
    }
    
    public void RestartBtn()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        btnSound.Play();
    }
    public void PauseBtn()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        btnSound.Play();
        pauseBtn.SetActive(false);
    }
    public void PausePanelPlayBtn()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        btnSound.Play();
        pauseBtn.SetActive(true);
    }
    
   
}
