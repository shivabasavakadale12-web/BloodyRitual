using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] LevelData[] Levels;
    public static LevelManager Instance;
    public int currentLevelIndex;
    public LevelData CurrentLevel => Levels[currentLevelIndex];
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

}
