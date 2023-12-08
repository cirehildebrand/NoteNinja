using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawnerScript : MonoBehaviour
{

    // Works for Porter robinson (Shelter)
    // private static float secondsPerBeat = 60.0f / 100.0f; // 100 BPM
    // float spawnInterval = secondsPerBeat * 2; // Spawn every 2 beats

    // A happy and generic 8-bit song
    private static float secondsPerBeat = 60.0f / 110.0f; // 110 BPM   
    // float spawnInterval = secondsPerBeat * 3; // Spawn every 3 beats
    float spawnInterval = secondsPerBeat * 2; // Spawn every 2 beats

    // Note Prefabs
    public GameObject noteGreenPrefab, noteRedPrefab, noteBluePrefab, noteOrangePrefab;
    //Prefabs for each type of hit effect
    public GameObject okEffect, goodEffect, perfectEffect, missEffect;
    private float nextSpawnTime = 0.0f;

    [SerializeField]
    private Sprite[] fruitSprites; // This array will hold your sprites

    // Song Notes
    // Hard Coded
    // private int[][] songNotes = { 
    //     new int []{0,0,0,0}, 
    //     new int []{1,0,0,1},
    //     new int []{1,1,1,1},
    //     new int []{0,0,0,0},};

    // Song Notes
    private int[][] songNotes;

    //TODO: Make a 3 second countdown before the song starts
    private int songNoteIndex = 0;
    private int songStartCtr = 8; //counter for the start of the song

    void AssignRandomFruit() {
            // Get the SpriteRenderer component of Prefabs
            SpriteRenderer spriteRenderer1 = noteGreenPrefab.GetComponent<SpriteRenderer>();
            SpriteRenderer spriteRenderer2 = noteRedPrefab.GetComponent<SpriteRenderer>();
            SpriteRenderer spriteRenderer3 = noteBluePrefab.GetComponent<SpriteRenderer>();
            SpriteRenderer spriteRenderer4 = noteOrangePrefab.GetComponent<SpriteRenderer>();

            // Assign random fruits
            int randomIndex = Random.Range(0, fruitSprites.Length);
            spriteRenderer1.sprite = fruitSprites[randomIndex];

            randomIndex = Random.Range(0, fruitSprites.Length);
            spriteRenderer2.sprite = fruitSprites[randomIndex];

            randomIndex = Random.Range(0, fruitSprites.Length);
            spriteRenderer3.sprite = fruitSprites[randomIndex];

            randomIndex = Random.Range(0, fruitSprites.Length);
            spriteRenderer4.sprite = fruitSprites[randomIndex];
    }

    //TODO: FIX THE TOTAL NUMBER OF BEATS!!! (numberOfBeats)
    void Start()
    {
        // Generate a random song pattern
        int numberOfBeats = 22; // Number of beats in the song
        int numberOfColumns = 4; // Number of columns (notes) in each beat
        songNotes = new int[numberOfBeats][];

        for (int beat = 0; beat < numberOfBeats; beat++)
        {
            songNotes[beat] = new int[numberOfColumns];
            for (int column = 0; column < numberOfColumns; column++)
            {
                // Generate a random 1 or 0 for each column
                songNotes[beat][column] = Random.Range(0, 2);
            }
        }
        songNotes[0] = new int []{0,1,0,1}; //hard coded first beat
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime && songNoteIndex < songNotes.Length)
        {
            // Assign random fruits
            AssignRandomFruit();

            // Calculate the spawn position at the top of the screen in 2D space.
            Vector3 spawnPosition1 = new Vector3(-7, 6.0f, 0.0f);
            Vector3 spawnPosition2 = new Vector3(-5, 6.0f, 0.0f);
            Vector3 spawnPosition3 = new Vector3(-3, 6.0f, 0.0f);
            Vector3 spawnPosition4 = new Vector3(-1, 6.0f, 0.0f);

            // Instantiate Note
            GameObject newNote1, newNote2, newNote3, newNote4;

            if(songStartCtr <= 0){
                // Spawn note if index [][x] is 1
                if(songNotes[songNoteIndex][0] == 1)
                    newNote1 = Instantiate(noteGreenPrefab, spawnPosition1, Quaternion.identity);
                if(songNotes[songNoteIndex][1] == 1)
                    newNote2 = Instantiate(noteRedPrefab, spawnPosition2, Quaternion.identity);
                if(songNotes[songNoteIndex][2] == 1)
                    newNote3 = Instantiate(noteBluePrefab, spawnPosition3, Quaternion.identity);
                if(songNotes[songNoteIndex][3] == 1)
                    newNote4 = Instantiate(noteOrangePrefab, spawnPosition4, Quaternion.identity);
                // Update the song note index.
                songNoteIndex += 1;
            } else
                songStartCtr -= 1;

            // Update the next spawn time.
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    public void doMissEffect(GameObject g)
    {
        Instantiate(missEffect, g.transform.position, missEffect.transform.rotation);
    }

    public void doOkEffect(GameObject g)
    {
        Instantiate(okEffect, g.transform.position, okEffect.transform.rotation);
    }

    public void doGoodEffect(GameObject g)
    {
        Instantiate(goodEffect, g.transform.position, goodEffect.transform.rotation);
    }

    public void doPerfectEffect(GameObject g)
    {
        Instantiate(perfectEffect, g.transform.position, perfectEffect.transform.rotation);
    }
}