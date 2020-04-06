using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject highscoreIndicator;
    public Text highscoreTxt;
    public AudioSource sfx;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Highscore"))
        {
            highscoreIndicator.SetActive(false);
        } else
        {
            highscoreIndicator.SetActive(true);
            if(PlayerPrefs.GetString("NewHighscore") == "yes")
            {
                sfx.Play();
                PlayerPrefs.SetString("NewHighscore", "none");
            }

            highscoreTxt.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

}
