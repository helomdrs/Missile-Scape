using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameRunning;

    public Text secondsTxt, minutesTxt;

    float timer;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (isGameRunning)
        {
            timer += Time.deltaTime;
            minutesTxt.text = Mathf.Floor(timer / 60).ToString("00");
            secondsTxt.text = Mathf.RoundToInt(timer % 60).ToString("00");
        }
    }

    public void PauseGame()
    {
        isGameRunning = !isGameRunning;
    }
}
