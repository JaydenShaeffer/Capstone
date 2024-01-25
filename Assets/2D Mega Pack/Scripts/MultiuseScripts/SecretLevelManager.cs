using UnityEngine;

public class SecretLevelManager : MonoBehaviour
{
    public static SecretLevelManager instance; // Singleton instance

    public string[] levelNames; // Names of the levels in order
    public static int SecretcurrentLevelIndex = 0;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string GetNextLevel()
    {
        ItemCollector.score = 0;
        if (SecretcurrentLevelIndex < levelNames.Length)
        {
            return levelNames[SecretcurrentLevelIndex++];
        }
        else
        {
            // No more levels, handle game completion or loop back to the first level
            // Example: currentLevelIndex = 0;
            return null;
        }
    }

    public void ResetLevelIndex()
    {
        LevelManager.secretStuck = false;
        Debug.Log("Log that ong fr - jeff");
        LoadingImageChanger.levelCount = 0;
        SecretLoadingImageChanger.levelCount = 0;
        LevelManager.currentLevelIndex = 0;
        SecretcurrentLevelIndex = 0;
    }
}
