using UnityEngine;

public class SecretLevelManager : MonoBehaviour
{
    public static SecretLevelManager instance; // Singleton instance

    public string[] levelNames; // Names of the levels in order
    public int currentLevelIndex = 0;

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

    public void ResetLevelIndex()
    {
        Debug.Log("Log that ong fr - jeff");
        LoadingImageChanger.levelCount = 0;
        currentLevelIndex = 0;
    }
}
