using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteMovement : MonoBehaviour
{
    private GameManager gameManager;
    private NoteSpawnerScript noteSpawner;
    private LifeManager lifeManager;

    public static float secondsPerBeat = 60f/110 ;// / 110bpm;
    public static float distancePerBeat = 1f;
    private float noteSpeed = distancePerBeat/secondsPerBeat; // Control the speed of notes.
    
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public KeyCode keyCode;

    //Random generate if rotated left/right & Speed
    private int rotation, rotationSpeed;

    //Score values for each type of hit
    public int scorePerOk = 5, scorePerGood = 10, scorePerPerfect = 20;

    void Start()
    {
        // Get the SpriteRenderer component attached to the GameObject.
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Init gameManager
        gameManager = FindObjectOfType<GameManager>();
        //Init NoteSpawner
        noteSpawner = FindObjectOfType<NoteSpawnerScript>();
        //Init LifeManager
        lifeManager = FindObjectOfType<LifeManager>();

        // Check if the SpriteRenderer component was found.
        if (spriteRenderer != null)
        {
            // Set the color of the sprite to red.
            originalColor = spriteRenderer.color;
        }
        else
        {
            // Handle the case where no SpriteRenderer component is found.
            Debug.LogError("SpriteRenderer component not found on the GameObject.");
        }

        //Randomly rotate left/right
        rotation = Random.Range(0, 2);
        //Randomly generate rotation speed
        rotationSpeed = Random.Range(10, 25);

    }

    void Update()
    {
        // Rotate the note based on the randomly determined rotation direction.
        if (rotation == 0)
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime); // Rotate right
        else
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime); // Rotate left

        // Move the note downward.
        transform.position += new Vector3(0, -noteSpeed * Time.deltaTime, 0); // Move the note downward.

        // Destroy the note when it goes out of the screen.
        // This should also say something like "Miss!" on the screen.
        if (transform.position.y < -5.0f)
        {
            noteSpawner.doMissEffect(gameObject);
            Destroy(gameObject);
            lifeManager.LoseLife();
        }
        
        //If note can be considered a hit
        if(transform.position.y <= -2.50 && transform.position.y >= -3.50)
        {
            //check if key is pressed
            if(Input.GetKeyDown(keyCode) && gameManager != null)
            {
                //Perfect hit (-2.9 to -3.1)
                if (transform.position.y <= -2.85 && transform.position.y >= -3.15)
                {
                    gameManager.SetScore(scorePerPerfect);
                    noteSpawner.doPerfectEffect(gameObject);
                }
                //Good hit (-2.7 to -3.3 and not a perfect)
                else if (transform.position.y <= -2.7 && transform.position.y >= -3.30)
                {
                    gameManager.SetScore(scorePerGood);
                    noteSpawner.doGoodEffect(gameObject);
                }
                //Ok hit (-2.5 to -3.5 and not a perfect or good)
                else
                {
                    gameManager.SetScore(scorePerOk);
                    noteSpawner.doOkEffect(gameObject);
                }
                
                Destroy(gameObject);
            }
        }else
        {
            // spriteRenderer.color = originalColor;
        }
    }
}
