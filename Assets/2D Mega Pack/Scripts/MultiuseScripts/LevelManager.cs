using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance; // Singleton instance

    public string[] levelNames; // Names of the levels in order
    public static int currentLevelIndex = 0;
    public ItemCollector itemCollector;
    public static bool secretStuck = false;

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
        if(ItemCollector.score <= 1000 && secretStuck == false)
        {
            if (currentLevelIndex < levelNames.Length)
            {
                return levelNames[currentLevelIndex++];
            }
            else
            {
                // No more levels, handle game completion or loop back to the first level
                // Example: currentLevelIndex = 0;
                return null;
            }
        }
        else 
        {
            return null;
        }
        
    }

    public void ResetLevelIndex()
    {
        secretStuck = false;
        Debug.Log("Log that ong fr - jeff");
        LoadingImageChanger.levelCount = 0;
        SecretLoadingImageChanger.levelCount = 0;
        currentLevelIndex = 0;
        SecretLevelManager.SecretcurrentLevelIndex = 0;
    }
}
