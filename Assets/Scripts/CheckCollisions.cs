using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    public float bounceSize;
    private Rigidbody _rigidbody;
    public Score score;
    public AudioSource bounceSound;
    private int bounceCount;

    public GameManager _GameManager;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
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
                bounceSound.Play();
                if (bounceCount == 0)
                    score.Scored();
                bounceCount++;
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("game over...!");
            _GameManager.GameOver();
            
        }
        
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Limit"))
        {
            Debug.Log("game over...!");
            _GameManager.GameOver();
        }
        else if (other.CompareTag("Exit"))
        {
            bounceCount = 0;
        }
    }
}
