using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreBoardSystem : MonoBehaviour
{
    private GameManager gameManager;
    
    // The text displayed to player
    public TMP_Text score;
    public TMP_Text songTimer;

    // The actual values
    public int scoreVal = 0;
    private int songMinutes = 0;
    private int songSeconds = 0;
    private float startTime;

    void Start(){
        // Sets default values
        gameManager = FindObjectOfType<GameManager>();
        songMinutes = 0;
        songSeconds = 0;
        startTime = Time.time;
        score.text = "SCORE: " + scoreVal;
        songTimer.text = "TIME: " + songMinutes + ":" + songSeconds;

        //Reset score for end screen
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();
    }

    void Update(){
        //Only updates scoreboard while game is unpaused
        if (gameManager != null)
            scoreVal = gameManager.GetScore();
        score.text = "SCORE: " + scoreVal.ToString("D4");

        //For transfering across scenes
        PlayerPrefs.SetInt("Score", scoreVal);
        PlayerPrefs.Save();
        
        float currentTime = Time.time - startTime;
        songMinutes = Mathf.FloorToInt(currentTime / 60);
        songSeconds = Mathf.FloorToInt(currentTime % 60);
        songTimer.text = "TIME: " + songMinutes + ":" + songSeconds.ToString("D2");

         //Move to game over screen after 30 seconds    
         if (songSeconds >= 40)
            SceneManager.LoadScene(2);
    }
}
