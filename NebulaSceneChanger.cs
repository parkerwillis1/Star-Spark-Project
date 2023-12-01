using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NebulaSceneChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (NebulaManager.instance != null && NebulaManager.instance.IsAllEnemiesDestroyed()) // Check if all enemies are destroyed
            {
                LoadNextScene(); // Load the next scene
            }
        }
    }

    private void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex; 
        int nextIndex = currentIndex + 1; 

        
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.LogWarning("No more scenes to load."); 
        }
    }
}



