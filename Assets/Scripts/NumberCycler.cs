using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberCycler : MonoBehaviour
{
    public Sprite[] numberSprites; // Array of sprites for numbers 0–9
    private SpriteRenderer spriteRenderer; // SpriteRenderer to display the images
    private int currentIndex = 0; // Tracks the current sprite index

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Display the first sprite
        if (numberSprites.Length > 0)
        {
            spriteRenderer.sprite = numberSprites[currentIndex];
        }
    }

    public void CycleNumber()
    {
        // Increment the index and wrap around after the last sprite
        currentIndex = (currentIndex + 1) % numberSprites.Length;

        // Update the displayed sprite
        spriteRenderer.sprite = numberSprites[currentIndex];
    }

    public int GetCurrentNumber()
    {
        return currentIndex;
    }

}
