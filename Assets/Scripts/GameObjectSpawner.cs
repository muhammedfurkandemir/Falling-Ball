using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawner : MonoBehaviour
{
    public GameObject[] grounds;
    public GameObject[] obstacles;
    float timer;
    public float maxTime;
    public float maxX;
    public float minX; 
    public float maxY;
    public float minY;
    public float minScaleX;
    float randomX; 
    float randomY;
    float randomScaleX;

    public void InstantiateGround(GameObject[] gameObjects)
    {
        randomX = Random.Range(minX, maxX);
        randomScaleX = Random.Range(minScaleX, 2 * minScaleX);        
      
        foreach (var item in gameObjects)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = new Vector3(randomX, transform.position.y, transform.position.z);
                item.transform.localScale = new Vector3(randomScaleX, transform.localScale.y, transform.localScale.z);
                break;
            }
            
        }
        
        
    }
    public void InstantiateObtacle(GameObject[] gameObjects)
    {
        randomX = Random.Range(minX, maxX);
        randomY = Random.Range(this.transform.position.y+minY, this.transform.position.y+ maxY);
        foreach (var newGameObject in gameObjects)
        {
            if (!newGameObject.activeInHierarchy)
            {
                newGameObject.SetActive(true);
                newGameObject.transform.position = new Vector3(randomX, randomY, transform.position.z);
                break;
            }
           
        }
        

    }


    void Update()
    {
        if (GameManager.gameStarted==true&&GameManager.gameOver==false)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                InstantiateGround(grounds);
                InstantiateObtacle(obstacles);
                timer = 0;
            }
        }
        
    }
}
