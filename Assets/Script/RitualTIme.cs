using TMPro;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class RitualTIme : MonoBehaviour
{
    [SerializeField] Spawners enemySpawner;
    [SerializeField] GameObject player;
    [SerializeField] GameObject yeartext;
    LevelManager levelManager;
    Combat playercombat;
    [SerializeField] GameObject WinMenu;
    [SerializeField]  Camera Mcamera;
    [SerializeField] TMP_Text timer; 
    [SerializeField] TMP_Text LevelNumber;
    [SerializeField] Image EndBg;
    [SerializeField] GameObject RitualParticle;
    [SerializeField] float ZoomSpeed = 5f;
    [SerializeField] GameObject ParticleEffect;
    [SerializeField] GameObject spotlight;
    [SerializeField] float FadeDuration;
    [SerializeField] GameObject EndSeqText;
    [SerializeField] GameObject Buttons;
    [SerializeField] GameObject Author;
    GameOer GameOver;
    float currentRitualTime;
    float maxSize = 6.4f;
    bool RitualEndedFlag = false;
    public bool Ritualended => RitualEndedFlag;
    public static event Action RitualEnded;
    const string UnlockedKey = "LevelUnlocked";
    void Start()
    {
        playercombat = FindAnyObjectByType<Combat>();
        playercombat.enabled = true;
        Debug.Log("Unlocked: " + PlayerPrefs.GetInt("LevelUnlocked", -1));
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
            if (Mcamera.orthographicSize >= 6.4f) return;
            Mcamera.orthographicSize += ZoomSpeed * Time.unscaledDeltaTime;
            Mcamera.orthographicSize = Mathf.SmoothDamp(Mcamera.orthographicSize, maxSize, ref ZoomSpeed, 0.5f);
            ParticleEffect.transform.localScale = Vector3.Lerp(ParticleEffect.transform.localScale, new Vector3(0, 0, 0), Time.unscaledDeltaTime * 15f);
            spotlight.transform.localScale = Vector3.Lerp(spotlight.transform.localScale, new Vector3(0, 0, 0), Time.unscaledDeltaTime * 15f);
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
            SaveProgress();
            StartCoroutine(RitualOverRoutine());
        }
    }

    void SaveProgress()
    {
        int newUnlocked = levelManager.currentLevelIndex + 1;
        int storedUnlocked = PlayerPrefs.GetInt(UnlockedKey, 0);

        if (newUnlocked > storedUnlocked)
        {
            PlayerPrefs.SetInt(UnlockedKey, newUnlocked);
            PlayerPrefs.Save();
        }
    }
    IEnumerator RitualOverRoutine()
    {
        if(playercombat != null)   playercombat.enabled = false;
        
        
        Debug.Log("CLI: " + levelManager.currentLevelIndex + " LLI: " + levelManager.levels.Length);
        if (levelManager.currentLevelIndex != levelManager.levels.Length - 1)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            RitualParticle.SetActive(true);
            yield return new WaitForSecondsRealtime(1f);
            WinMenu.SetActive(true);
        }

        else
        {
            StartCoroutine(EndSequenceRoutine());
        }
    }


    IEnumerator EndSequenceRoutine()
    {

        Color c = EndBg.color;
        c.a = 0f;
        EndBg.color = c;
        EndBg.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        float alpha = 0f;
        while (alpha < 1)
        {
            alpha = Mathf.MoveTowards(alpha, 1f, Time.unscaledDeltaTime / FadeDuration);
            c.a = alpha;
            EndBg.color = c;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(2f);
        yeartext.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        Destroy(yeartext);
        yield return new WaitForSecondsRealtime(2f);
        EndSeqText.SetActive(true);
        Debug.Log( "is endseq true: " + EndSeqText);
        yield return new WaitForSecondsRealtime(5f);
        Author.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        Buttons.SetActive(true);

    }
    public void NextButton()
    {
      
        levelManager.LevelSelection(levelManager.currentLevelIndex + 1);

        if (!levelManager.levelExists) return;
        Time.timeScale = 1f;
        SceneManager.LoadScene("LoadScreen");
        StartCoroutine(RitualRoomRoutine());
    }

    IEnumerator RitualRoomRoutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("RitualRoom");

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
