using TMPro;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

public class RitualTIme : MonoBehaviour
{
    [SerializeField] Spawners enemySpawner;
    [SerializeField] GameObject player;
    LevelManager levelManager;
    [SerializeField] GameObject WinMenu;
    [SerializeField]  Camera Mcamera;
    [SerializeField] TMP_Text timer; 
    [SerializeField] TMP_Text LevelNumber;
    [SerializeField] GameObject RitualParticle;
    [SerializeField] float ZoomSpeed = 5f;
    [SerializeField] GameObject ParticleEffect;
    [SerializeField] GameObject spotlight;
    GameOer GameOver;
    float currentRitualTime;
    float maxSize = 6.4f;
    bool RitualEndedFlag = false;
    public bool Ritualended => RitualEndedFlag;
    public static event Action RitualEnded;
    void Start()
    {
        GameOver = GetComponent<GameOer>();
        RitualParticle.SetActive(false);
        Time.timeScale = 1f;
        levelManager = LevelManager.Instance;
        Mcamera.orthographicSize = 5.72f;
        WinMenu.SetActive(false);
        LevelNumber.text = levelManager.CurrentLevel.levelNumber.ToString("00");
        currentRitualTime = levelManager.CurrentLevel.RitualTime;
    }

    void Update()
    {
        if (GameOver.Gameover) return;
        if (RitualEndedFlag)
        {
            Mcamera.orthographicSize += ZoomSpeed * Time.unscaledDeltaTime;
            Mcamera.orthographicSize = Mathf.SmoothDamp(Mcamera.orthographicSize, maxSize, ref ZoomSpeed, 0.5f);
            ParticleEffect.transform.localScale = Vector3.Lerp(ParticleEffect.transform.localScale, new Vector3(0, 0, 0), Time.unscaledDeltaTime * 15f);
            spotlight.transform.localScale = Vector3.Lerp(spotlight.transform.localScale, new Vector3(0, 0, 0), Time.unscaledDeltaTime * 15f);
            Debug.Log(Mcamera.orthographicSize + " is the size ");
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
            RitualEndedFlag = true;
            RitualEnded?.Invoke();
            currentRitualTime = 0f;
            StartCoroutine(RitualOverRoutine());
        }
    }
    IEnumerator RitualOverRoutine()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        RitualParticle.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        WinMenu.SetActive(true);
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
