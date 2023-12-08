using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] public GameObject menuButton;

    //Text for final score 
    public TMP_Text scoreText;

    void Start()    {
        int finalScore = PlayerPrefs.GetInt("Score");
        scoreText.text = "Your final score was: " + finalScore + " points. \nThank you for playing!";
        Debug.Log("Start Final Score " + finalScore);
    }

    public void ReturnToMenu(){
        SceneManager.LoadScene(0);
    }
}

