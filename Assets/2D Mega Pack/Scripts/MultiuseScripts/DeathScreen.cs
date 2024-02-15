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
       // LevelManager.instance.ResetLevelIndex();
        Debug.Log(LevelManager.currentLevelIndex);
        LevelManager.currentLevelIndex = LevelManager.currentLevelIndex - 1;
        LoadingImageChanger.levelCount = LoadingImageChanger.levelCount - 1;
        // Load the MainMenu scene
        SceneManager.LoadScene(LevelManager.currentLevelIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
