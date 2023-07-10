using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddedScore : MonoBehaviour
{
    public int addedScore;
    public Text addedScoreText;
    public Animator _anim;
    private Vector3 startPos;
    public Score score;
    private void OnEnable()
    {
        addedScore = 0;
        addedScoreText.text = addedScore.ToString();
        
    }
    void Start()
    {
        startPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddedScored()
    {
        addedScore++;
        addedScoreText.text = "+" + addedScore.ToString();
        Debug.Log(addedScore);
    }
    public void AddedScoredEnd()
    {
        _anim.Play("AddedScoreTextAnim");
        StartCoroutine(DeActive());
    }
    IEnumerator DeActive()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
        StopCoroutine(DeActive());
    }
    private void OnDisable()
    {
        Debug.Log("on disable çalıştı");
        score.AddScored(addedScore);
        this.transform.position = startPos;        
    }
}
