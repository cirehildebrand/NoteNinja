using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UNUSED CODE (BUT) good reference for future use

public class NoteCollision : MonoBehaviour
{
    private bool canDestroy = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("HitBox"))
        {
            canDestroy = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("HitBox"))
        {
            canDestroy = false;
        }
    }

    private void Update()
    {
        if (canDestroy && Input.GetKeyDown(KeyCode.G))
        {
            Destroy(gameObject);
        }
    }
}