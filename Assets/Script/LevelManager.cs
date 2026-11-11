using Unity.Mathematics;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] LevelData[] Levels;
    public static LevelManager Instance;
    public int currentLevelIndex;
    bool LevelExists = false;
    public int GetCurrentYear => Levels[currentLevelIndex].Year;
    public bool levelExists => LevelExists;
    public LevelData CurrentLevel => Levels[currentLevelIndex];
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        int level = PlayerPrefs.GetInt("LevelUnlocked", 0);
        Debug.Log("Unlocked: " + level);
        int maxlevel  =  math.clamp(level, 0, Levels.Length - 1);
        LevelSelection(maxlevel);
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
