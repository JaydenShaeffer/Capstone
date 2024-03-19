using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public string LoadingScreen;
    public string mainMenuScene;

    public void Start()
    {
        Debug.Log(LevelManager.currentLevelIndex);
    }
    public void Retry()
    {
        // Reset the currentLevelIndex before loading the main menu scene
       // LevelManager.instance.ResetLevelIndex();
        ItemCollector.isPoweredUp = false;
        Projectile.damage = Projectile.defaultDMG;
        LevelManager.currentLevelIndex = LevelManager.currentLevelIndex - 1;
        LoadingImageChanger.levelCount = LoadingImageChanger.levelCount - 1;
        // Load the MainMenu scene
        Debug.Log(LevelManager.currentLevelIndex);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
