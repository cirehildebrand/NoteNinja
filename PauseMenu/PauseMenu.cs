using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public bool getPaused(){
        return GameIsPaused;
    }

    public void setPause(bool pause){
        GameIsPaused = pause;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(GameIsPaused) // if game is already paused
            {
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false); // hide menu
        Time.timeScale = 1f; // unfreeze
        GameIsPaused = false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true); // display our pause menu
        Time.timeScale = 0f; // Freeze time
        GameIsPaused = true;
    }

    public void LoadMenu(){
        Time.timeScale = 1f; // unfreezes
        SceneManager.LoadScene(0);
    }

    public void QuitGame(){
        Debug.Log("Quitting Game");
        Application.Quit();

    }
}
