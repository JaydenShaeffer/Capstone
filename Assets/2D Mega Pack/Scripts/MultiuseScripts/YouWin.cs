using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class YouWin : MonoBehaviour
{
    public string LoadingScreen;
    public string mainMenuScene;

    public void Start()
    {
        Debug.Log(LevelManager.currentLevelIndex);
    }
    public void PlayAgain()
    {
        // Reset the currentLevelIndex before loading the main menu scene
       // LevelManager.instance.ResetLevelIndex();
        ItemCollector.isPoweredUp = false;
        GojoScript.domainExpansion = false;
        LevelManager.secretStuck = false;
        Projectile.damage = Projectile.defaultDMG;
        LevelManager.currentLevelIndex = LevelManager.currentLevelIndex = 0;
        LoadingImageChanger.levelCount = LoadingImageChanger.levelCount = 0;
        SecretLevelManager.SecretcurrentLevelIndex = 0;
        SecretLoadingImageChanger.levelCount = 0;
        // Load the MainMenu scene
        Debug.Log($"Level Manger Index: {LevelManager.currentLevelIndex}");
        Debug.Log($"Loading image changer: {LoadingImageChanger.levelCount}");
        Debug.Log($"Secret level manager index: {SecretLevelManager.SecretcurrentLevelIndex}");
        Debug.Log($"Secret image changer: {SecretLoadingImageChanger.levelCount}");
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
