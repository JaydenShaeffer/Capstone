using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public string mainMenuScene;

    public void Retry()
    {
        // Reset the currentLevelIndex before loading the main menu scene
        LevelManager.instance.ResetLevelIndex();
        
        // Load the MainMenu scene
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
