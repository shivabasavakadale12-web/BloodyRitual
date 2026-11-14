using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] LevelData[] Levels;
    public LevelData[] levels => Levels;
    public static LevelManager Instance;
    KillCounter killCounter;
    public int currentLevelIndex;
    bool LevelExists = false;
    public int GetCurrentYear => Levels[currentLevelIndex].Year;
    public bool levelExists => LevelExists;
    public LevelData CurrentLevel => Levels[currentLevelIndex];
    int Attempts = 0;
    public int attempts => Attempts;
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
        int maxlevel  =  math.clamp(level, 0, Levels.Length - 1);
        LevelSelection(maxlevel);
    }

    private void Start()
    {
        killCounter = FindAnyObjectByType<KillCounter>();
    }

    public void Reset()
    {

        Time.timeScale = 1f;

        Attempts = 0;
        LevelSelection(0);
        Debug.Log("Lund fuckaer hai");
        SceneManager.LoadScene("LoadScreen");
    }
    public void TestButton()
    {
        Debug.Log("RESTART BUTTON RECEIVED CLICK");
    }
    public void PlayerChance(int Count)
    {
        Attempts += Count;
    }

    public void LevelSelection(int levelIndex)
    {
        if(levelIndex < 0 || levelIndex >= Levels.Length)
        {
            LevelExists = false;
            return;
        }
        LevelExists = true;
        currentLevelIndex = levelIndex;

    }

}
