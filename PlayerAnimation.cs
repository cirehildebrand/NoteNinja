using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // public AnimationClip animationClipA;
    // public AnimationClip animationClipB;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //animator.SetTrigger("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        // Check for 'A' or 'B' key press
        if (Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.F) ||
            Input.GetKeyDown(KeyCode.J) ||
            Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("Attack");
        }
    }
}
