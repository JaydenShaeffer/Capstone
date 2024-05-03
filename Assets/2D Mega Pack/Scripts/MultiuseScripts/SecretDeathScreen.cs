using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretDeathScreen : MonoBehaviour
{
    public string LoadingScreen;
    public string mainMenuScene;
    public string SecretLevelScene;
    public ItemCollector ItemCollector;

    public void Start()
    {
        Debug.Log(LevelManager.currentLevelIndex);
    }
    public void Retry()
    {
        /*if (ItemCollector.secret == false && LevelManager.secretStuck == false)
        {
            // Reset the currentLevelIndex before loading the main menu scene
            // LevelManager.instance.ResetLevelIndex();
            ItemCollector.isPoweredUp = false;
            GojoScript.domainExpansion = false;
            Projectile.damage = Projectile.defaultDMG;
            LevelManager.currentLevelIndex = LevelManager.currentLevelIndex - 1;
            LoadingImageChanger.levelCount = LoadingImageChanger.levelCount - 1;
            // Load the MainMenu scene
            Debug.Log(LevelManager.currentLevelIndex);
            SceneManager.LoadScene(1);
        }*/
        //if (ItemCollector.secret == true && LevelManager.secretStuck == true)
        {
            SecretLevelManager.SecretcurrentLevelIndex = SecretLevelManager.SecretcurrentLevelIndex - 1;
            SecretLoadingImageChanger.levelCount = SecretLoadingImageChanger.levelCount - 1;
            SceneManager.LoadScene(SecretLevelScene);
            ItemCollector.isPoweredUp = false;
            Projectile.damage = Projectile.defaultDMG;
        }
       
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
