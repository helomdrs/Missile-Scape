using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreTxt;
    public GameManager manager;

    public float score;

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

    public void SetHighscore()
    {
        if (!PlayerPrefs.HasKey("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", Mathf.RoundToInt(score));
            PlayerPrefs.SetString("NewHighscore", "yes");
        }
        else
        {
            if (PlayerPrefs.GetInt("Highscore") < score)
            {
                PlayerPrefs.SetInt("Highscore", Mathf.RoundToInt(score));
                PlayerPrefs.SetString("NewHighscore", "yes");
            }

            PlayerPrefs.SetString("NewHighscore", "no");
        }

        Debug.Log("Highscore: " + PlayerPrefs.GetInt("Highscore"));
    }
}
