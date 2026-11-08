using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] LevelData[] Levels;
    public static LevelManager Instance;
    public int currentLevelIndex;
    bool LevelExists = false;
    public bool levelExists => LevelExists;
    public LevelData CurrentLevel => Levels[currentLevelIndex];
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void LevelSelection(int levelIndex)
    {
        if(levelIndex < 0 || levelIndex >= Levels.Length)
        {
            LevelExists = false;
            Debug.LogError("Invalid level index: " + levelIndex);
            return;
        }
        LevelExists = true;
        currentLevelIndex = levelIndex;
    }

}
