using TMPro;
using UnityEngine;

public class CurrentLevel : MonoBehaviour
{
    [SerializeField] LevelData levelData;
    [SerializeField] TMP_Text LevelNumber;
    void Start()
    {
        LevelNumber.text = levelData.levelNumber.ToString("00");
    }
}
