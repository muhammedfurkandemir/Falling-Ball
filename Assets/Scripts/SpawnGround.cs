using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public GameObject ground;
    float timer;
    public float maxTime;
    public float maxX;
    public float minX;
    float randomX;

    public void InstantiateGround()
    {
        randomX = Random.Range(minX, maxX);
        GameObject newGround = Instantiate(ground);
        newGround.transform.position = new Vector3(randomX, transform.position.y,transform.position.z);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=maxTime)
        {
            InstantiateGround();
            timer = 0;
        }
    }
}
