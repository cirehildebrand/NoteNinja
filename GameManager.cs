using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //static public GameManager instance;
    private int playerScore = 0;

    [SerializeField]
    private AudioClip[] audioClips;
    private AudioSource audioSource;

    public void SetScore(int score)
    {
        playerScore += score;
        Debug.Log("Score: " + playerScore);
    }
    public int GetScore()
    {
        return playerScore;
    }

    private void PlayAudio(int index)
    {
        // Check if the index is valid
        if (index >= 0 && index < audioClips.Length)
        {
            // Set the AudioClip to play on the AudioSource
            audioSource.clip = audioClips[index];
            // Play the AudioClip
            audioSource.Play();
        }
    }

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.F) ||
            Input.GetKeyDown(KeyCode.J) ||
            Input.GetKeyDown(KeyCode.K))
        {
             PlayAudio(Random.Range(0, audioClips.Length)); //Play a random audio clip
        }
    }
}
