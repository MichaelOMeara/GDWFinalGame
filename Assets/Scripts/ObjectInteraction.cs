using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public bool isInteractable = true;

    void OnMouseDown()
    {
        if (isInteractable)
        {
            // Call a function to handle the interaction
            HandleInteraction();
        }
    }

    void HandleInteraction()
    {
        Debug.Log($"Interacted with {gameObject.name}");
        // Add your interaction logic here
    }
}
