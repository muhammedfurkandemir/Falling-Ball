using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    public float bounceSize;
    private Rigidbody _rigidbody;

  
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
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y + bounceSize, _rigidbody.velocity.z);
            Debug.Log("çarptı");
            
            GameManager.score++;
                
            
               
        }
        
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Limit"))
        {
            Debug.Log("game over...!");
        }
    }
}
