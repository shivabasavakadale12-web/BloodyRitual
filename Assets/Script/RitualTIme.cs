using TMPro;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class RitualTIme : MonoBehaviour
{
    [SerializeField] Spawners enemySpawner;
    [SerializeField] GameObject player;
    LevelManager levelManager;
    [SerializeField] GameObject WinMenu;
    [SerializeField]  Camera Camera;
    [SerializeField] TMP_Text timer; 
    [SerializeField] TMP_Text LevelNumber; 
    [SerializeField]  float ZoomSpeed = 5f;
    float currentRitualTime;
    float minSize = 5f;
    float maxSize = 6.4f;
    bool levelended = false;

    public static event Action RitualEnded;
    void Start()
    {
        Time.timeScale = 1f;
        levelManager = LevelManager.Instance;
        WinMenu.SetActive(false);
        LevelNumber.text = levelManager.CurrentLevel.levelNumber.ToString("00");
        currentRitualTime = levelManager.CurrentLevel.RitualTime;
    }

    void Update()
    {
        if (levelended)
        {
         Camera.orthographicSize += ZoomSpeed * Time.unscaledDeltaTime;
         Camera.orthographicSize = Mathf.Clamp(Camera.orthographicSize, maxSize, minSize);
         return;
        }
        currentRitualTime -= Time.deltaTime;

        timer.text = Mathf.Ceil(currentRitualTime).ToString("00");
        if (currentRitualTime <= 0)
        {
            if (enemySpawner != null)
            {
                enemySpawner.StopSpawning();
            }
            if (player != null)
            {
                player.GetComponent<Combat>().enabled = false;
                player.GetComponent<PlayerLane>().enabled = false;
                player.GetComponent<PlayerMovement>().enabled = false;
            }


            levelended = true;
            RitualEnded?.Invoke();
            currentRitualTime = 0f;
            WinMenu.SetActive(true);
        }
    }

    public void NextButton()
    {
        levelManager.LevelSelection(levelManager.currentLevelIndex + 1);

        if (!levelManager.levelExists) return;
        Time.timeScale = 1f;
        SceneManager.LoadScene("RitualRoom");
        Debug.Log("Bruh Implement the logic dumbass idiot");
    }

    public void HomePage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
