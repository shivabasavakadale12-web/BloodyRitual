using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RitualTIme : MonoBehaviour
{
    [SerializeField] LevelData LevelData;
    [SerializeField] GameObject WinMenu;
    [SerializeField] TMP_Text timer; 

    float currentRitualTime;
    void Start()
    {
        WinMenu.SetActive(false);
        currentRitualTime = LevelData.RitualTime;
    }

    void Update()
    {
        currentRitualTime -= Time.deltaTime;

        timer.text = Mathf.Ceil(currentRitualTime).ToString("00");
        if (currentRitualTime <= 0)
        {
            currentRitualTime = 0f;
            Time.timeScale = 0f;
            WinMenu.SetActive(true);
        }
    }

    public void NextButton()
    {
        Time.timeScale = 1f;
        Debug.Log("Bruh Implement the logic dumbass idiot");
    }

    public void HomePage()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
