using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMusic : MonoBehaviour
{
    public AudioSource audioSource;
    private PauseMenu pauseMenu;

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        pauseMenu = FindObjectOfType<PauseMenu>();
        // isPaused = pauseMenu.GameIsPaused;

        pauseMenu.setPause(false);
    }

    void Update()
    {
        // Check the boolean value and pause or resume the audio accordingly
        if (pauseMenu.getPaused())
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
    }
}