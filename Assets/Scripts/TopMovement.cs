using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMovement : MonoBehaviour
{
    public float moveSpeed;
    private void OnEnable()
    {
        if (GameManager.gameStarted == true && GameManager.gameOver == false)
        {
            StartCoroutine(GameObjectDeactive());
        }
    }
    void Update()
    {
        if(GameManager.gameOver == false && GameManager.gameStarted == true)
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed); 
    }
    IEnumerator GameObjectDeactive()
    {
        yield return new WaitForSeconds(25f);
        if (GameManager.gameStarted == true && GameManager.gameOver == false)
        {
            gameObject.SetActive(false);
        }
    }
  

}
