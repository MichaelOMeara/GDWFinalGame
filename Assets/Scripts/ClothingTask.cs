using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingTask : MonoBehaviour
{
    public SpriteRenderer playerSprite; // Player's SpriteRenderer
    public Sprite[] clothingSprites;   // Sprites for each clothing stage
    public GameObject doorCodePrefab;  // Prefab to reveal the door code
    public Transform codeSpawnPoint;   // Location where the door code will appear

    private int clothingCount = 0;     // Tracks how many clothing items have been put on
    private int totalClothingItems = 4; // Total number of clothing items

    void Update()
    {
        // Check if all clothing items have been put on
        if (clothingCount >= totalClothingItems)
        {
            RevealDoorCode();
        }
    }

    public void EquipClothingItem()
    {
        // Increment clothing count
        clothingCount++;

        // Update player's appearance
        if (clothingCount <= clothingSprites.Length)
        {
            playerSprite.sprite = clothingSprites[clothingCount - 1];
        }
    }

    private void RevealDoorCode()
    {
        // Spawn the door code
        if (doorCodePrefab != null && codeSpawnPoint != null)
        {
            Instantiate(doorCodePrefab, codeSpawnPoint.position, Quaternion.identity);
        }

        // Prevent multiple door code reveals
        enabled = false; // Disable this script once task is complete
    }
}