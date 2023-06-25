using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMovement : MonoBehaviour
{
    public float moveSpeed;

    void Start()
    {
        Destroy(gameObject,10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed); 
    }
    
}
