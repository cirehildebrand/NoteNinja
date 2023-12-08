using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private KeyCode KeyCode;

    [SerializeField]
    private Color outputColor;

    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode))
        {
            spriteRenderer.color = outputColor;
        }
        else if(Input.GetKeyUp(KeyCode))
        {
            spriteRenderer.color = originalColor;
        }
    }
}
