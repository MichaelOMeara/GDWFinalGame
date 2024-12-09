using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabOnClick : MonoBehaviour
{
    public GameObject prefabToInstantiate; // The prefab to instantiate
    public Transform spawnLocation;        // The location where the prefab will be instantiated

    private void OnMouseDown()
    {
        if (prefabToInstantiate != null)
        {
            // Instantiate the prefab at the specified location and rotation
            Instantiate(prefabToInstantiate, spawnLocation.position, spawnLocation.rotation);
        }
    }
}