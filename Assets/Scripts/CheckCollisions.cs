using System.Collections;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    public float bounceSize;
    public float bounceDownVelocitySize;
    private Rigidbody _rigidbody;
    public Score score;
    public AddedScore addedScore;
    public GameObject addedScoreGameObject;
    public AudioSource bounceSound;
    public AudioSource gameOverSound;
    private int bounceCount;

    public GameManager _GameManager;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {    
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameStarted == true && GameManager.gameOver == false)
            {
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y + bounceSize, _rigidbody.velocity.z);
                _rigidbody.AddTorque(new Vector3(0, bounceSize, 0));
                StartCoroutine(DownVelocityTimer());
                bounceSound.Play();
                if (bounceCount == 0)
                {
                    score.Scored();
                    if (addedScoreGameObject.activeSelf==true)
                        addedScore.AddedScoredEnd();                    
                }
                bounceCount++;
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("game over...!");
            gameOverSound.Play();
            _GameManager.GameOver();

        }
        
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Limit"))
        {
            Debug.Log("game over...!");
            gameOverSound.Play();
            _GameManager.GameOver();
        }
        else if (other.CompareTag("Exit"))
        {
            
            if (bounceCount==0)
            {
                addedScoreGameObject.SetActive(true);
                addedScore.AddedScored();
            }
            bounceCount = 0;

        }
    }
    IEnumerator DownVelocityTimer()
    {
        yield return new WaitForSeconds(0.3f);
        if (!_rigidbody.isKinematic)
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y + -bounceDownVelocitySize, _rigidbody.velocity.z);
        StopCoroutine(DownVelocityTimer());
    }
}
