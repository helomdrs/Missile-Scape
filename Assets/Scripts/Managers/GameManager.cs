using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameRunning;

    public GameObject pausePanel;
    public GameObject controls;
    public Text secondsTxt, minutesTxt;

    float timer;
    
    void Start()
    {
        pausePanel.SetActive(false);
        controls.SetActive(true);
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
        isGameRunning = false;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        controls.SetActive(false);
    }

    public void UnpauseGame()
    {
        isGameRunning = true;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        controls.SetActive(true);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
