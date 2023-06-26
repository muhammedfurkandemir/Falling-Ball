using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMovement : MonoBehaviour
{
    public float moveSpeed;


    private void OnEnable()
    {
        StartCoroutine(GameObjectDeactive());
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed); 
    }
    IEnumerator GameObjectDeactive()
    {
        yield return new WaitForSeconds(25f);
        gameObject.SetActive(false);
    }
  

}
