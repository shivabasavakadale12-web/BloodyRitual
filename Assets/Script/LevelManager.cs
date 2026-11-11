using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    [SerializeField] LevelData[] Levels;
    public static LevelManager Instance;
    KillCounter killCounter;
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

    private void Start()
    {
        killCounter = FindAnyObjectByType<KillCounter>();
    }

    void Update()
    {
        if(currentLevelIndex == Levels.Length - 1)
        {
            Debug.Log("Final level");
            //check player performs from level 3 and 4 to decide they win or lose this round
        }

        if(Keyboard.current.bKey.isPressed)
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("LevelProgress have been deleted");
        }
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
