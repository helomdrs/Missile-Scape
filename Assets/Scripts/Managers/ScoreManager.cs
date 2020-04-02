using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreTxt;
    public GameManager manager;

    float score;

    void Start()
    {
        
    }

    void Update()
    {
        if (manager.isGameRunning)
        {
            score += Time.deltaTime;
            scoreTxt.text = Mathf.RoundToInt(score).ToString();
        } 

    }

    public void AddScorePerCoin(int coinValue)
    {
        score += coinValue;
        scoreTxt.text = Mathf.RoundToInt(score).ToString();
    }
}
