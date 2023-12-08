using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    private GameManager gameManager;
    public TextMeshPro scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //Init gameManager
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(gameManager != null)
            scoreText.text = "SCORE: " + gameManager.GetScore();
    }
}
