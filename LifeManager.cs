using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public Image[] hearts;
    public int currentLives; // Store the current number of lives.

    void Start()
    {
        currentLives = 5;
        for (int i = 0; i < currentLives; i++)
            hearts[i].enabled = true;
    }

    public void LoseLife()
    {
        //Reduce lives remaining
        currentLives--;

        //Hide a heart based on lives lost
        if (currentLives >= 0)
            hearts[currentLives].enabled = false;
        else
            return;

        if (currentLives <= 0)
        {
            Debug.Log("You lose");
            SceneManager.LoadScene(2);
        }
    }
}

