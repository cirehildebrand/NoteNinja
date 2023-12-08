using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject optionsMenu;

    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("QUIT");
    }

    public void gotoOptionsMenu(){
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Back(){
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
