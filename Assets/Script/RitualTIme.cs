using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RitualTIme : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField] GameObject WinMenu;
    [SerializeField] TMP_Text timer; 
    bool levelended = false;
    float currentRitualTime;

    void Start()
    {
        Time.timeScale = 1f;
        levelManager = LevelManager.Instance;
        WinMenu.SetActive(false);
        currentRitualTime = levelManager.CurrentLevel.RitualTime;
    }

    void Update()
    {
        if (levelended) return;
        currentRitualTime -= Time.deltaTime;

        timer.text = Mathf.Ceil(currentRitualTime).ToString("00");
        if (currentRitualTime <= 0)
        {
            currentRitualTime = 0f;
            Time.timeScale = 0f;
            WinMenu.SetActive(true);
            levelended = true;
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
