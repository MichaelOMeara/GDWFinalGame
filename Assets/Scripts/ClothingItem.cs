using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingItem : MonoBehaviour
{
    private bool isEquipped = false; // Track if the item has already been used

    private void OnMouseDown()
    {
        if (!isEquipped)
        {
            // Find the player and equip the clothing item
            ClothingTask playerTask = FindObjectOfType<ClothingTask>();
            if (playerTask != null)
            {
                playerTask.EquipClothingItem();
            }

            // Mark this item as equipped and hide it
            isEquipped = true;
            gameObject.SetActive(false);
        }
    }
}
