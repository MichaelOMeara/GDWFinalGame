using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateChecker : MonoBehaviour
{
    public NumberCycler[] cyclers; // Array of NumberCycler objects to check
    public int[] correctValues; // The correct values for each cycler
    public GameObject codePrefab; // Prefab to display the success code
    public Transform spawnPoint; // Where the prefab will appear

    private void Update()
    {
        // Check all cyclers when the player presses the 'E' key
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (AreCoordinatesCorrect())
            {
                Debug.Log("Coordinates are correct!");
                RevealCode();
            }
            else
            {
                Debug.Log("Coordinates are incorrect. Try again!");
            }
        }
    }

    private bool AreCoordinatesCorrect()
    {
        for (int i = 0; i < cyclers.Length; i++)
        {
            if (cyclers[i].GetCurrentNumber() != correctValues[i])
            {
                return false;
            }
        }
        return true;
    }

    private void RevealCode()
    {
        if (codePrefab != null && spawnPoint != null)
        {
            GameObject codeInstance = Instantiate(codePrefab, spawnPoint.position, Quaternion.identity);
            Destroy(codeInstance, 10f); // Destroy after 10 seconds
        }
        else
        {
            Debug.LogWarning("Code prefab or spawn point is not set!");
        }
    }
}
