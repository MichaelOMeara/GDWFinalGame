using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI GameOverText; // Reference to the "Game Over" Text
    public Button Reset; // Reference to the Reset Button

    private void Start()
    {
        // Ensure "Game Over" text and Reset button are hidden initially
        if (GameOverText != null)
        {
            GameOverText.gameObject.SetActive(false);
        }
        if (Reset != null)
        {
            Reset.gameObject.SetActive(false);
            Reset.onClick.AddListener(ResetScene);
        }
    }

    public void PlayerDestroyed()
    {
        if (GameOverText != null)
        {
            GameOverText.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("GameOverText is null or destroyed.");
        }

        if (Reset != null)
        {
            Reset.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Reset button is null or destroyed.");
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}