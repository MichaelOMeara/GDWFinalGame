using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    private int currentObjective = 0;

    public string[] objectives;

    public void CompleteObjective()
    {
        if (currentObjective < objectives.Length)
        {
            Debug.Log($"Objective Completed: {objectives[currentObjective]}");
            currentObjective++;
        }

        if (currentObjective == objectives.Length)
        {
            Debug.Log("All objectives completed! You win!");
            // Trigger win condition
        }
    }
}
