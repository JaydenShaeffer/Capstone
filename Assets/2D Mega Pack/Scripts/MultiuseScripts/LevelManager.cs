using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance; // Singleton instance

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
        currentLevelIndex = 0;
    }
}
