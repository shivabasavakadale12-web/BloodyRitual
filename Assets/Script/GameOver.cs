using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOer : MonoBehaviour
{
    [SerializeField] GameObject LostText;
    [SerializeField] TMP_Text endText;
    [SerializeField] GameObject LostMenu;
    [SerializeField] Camera Camera;
    [SerializeField] DestroyObjects sister;
    [SerializeField] DestroyObjects player;
    [SerializeField] GrayscaleEffect effect;
    [SerializeField] GameObject FireEffect;
    [SerializeField] AudioClip ExplosionSound;
    [SerializeField] float ZoomSpeed = 50f;
    [SerializeField] float rotateSpeed = 50f;
    LevelManager levelmanager;
    RitualTIme RitualTime;
    float minSize = 3;
    float maxSize = 7;
    bool gameover = false;
    bool gameEnd = false;
    public bool Gameover => gameover;

    public static GameOer Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        levelmanager = LevelManager.Instance;
        RitualTime = GetComponent<RitualTIme>();
        LostMenu.SetActive(false);
        endText.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(RitualTime.Ritualended) return;
            levelmanager.PlayerChance(1);
        gameover = true;
        Debug.Log("game over");
        Time.timeScale = 0.35f;
        StartCoroutine(LoadSceneRoutine(collision));
    }

    void Update()
    {
        if (gameover)
        {
            Camera.orthographicSize += ZoomSpeed * Time.unscaledDeltaTime;
            Camera.transform.Rotate(Vector3.forward, rotateSpeed * Time.unscaledDeltaTime);
            Camera.orthographicSize = Mathf.Clamp(Camera.orthographicSize, minSize, maxSize);
        }

    }
    public void EndSeq()
    {

        if (gameEnd) return;
        if (levelmanager.attempts > 22)
        {
            endText.text = "Fourteen years had passed again, and this time Lian did not send her ghosts. She came herself.\r\n\r\nShe only wanted to be seen. The others wanted more. They took her power from her, and it made them hungry in a way she had never been.\r\n\r\nYou held the door as long as you could. It was not long enough. The ritual went quiet before the last candle did.\r\n\r\nThe family burned for the first time. Lian stood in the doorway and watched, and she did not smile.\r\n\r\nShe was fourteen once. That was all she ever was.\r\n\r\nThe End".ToString();
            gameEnd = true;
        }

        else if (levelmanager.attempts <= 22)
        {
            endText.text = "Fourteen years had passed again, and this time she did not send her ghosts. Lian came herself.\r\n\r\nShe never raised a hand against anyone. She only walked toward the ritual, slowly, the way a child walks home after dark. You stood in her way anyway.\r\n\r\nWhen the last candle burned out, so did she, for the second time. Your sister was alive. The family slept soundly that night and burned incense for the living. No one burned any for her.\r\n\r\nOnce, they had called it honor. Tonight, you called it survival. The silence afterward sounded exactly the same.\r\n\r\nThe End".ToString();
            gameEnd = true;
        }

    }
    IEnumerator LoadSceneRoutine(Collider2D collision)

    {
        effect.EnableGrayscale();
        yield return new WaitForSecondsRealtime(1);
        if (collision != null)
        {
            sister.OnDestroy();
            FireEffect.SetActive(true);
            AudioSource.PlayClipAtPoint(ExplosionSound, Camera.transform.position);
            if (player != null)
                player.OnDestroy();
        }
        yield return new WaitForSecondsRealtime(2f);
        LostText.SetActive(true);
        yield return new WaitForSecondsRealtime(1.6f);
        LostMenu.SetActive(true);
        Time.timeScale = 0f;
        gameover = false;
    }

    public void Restart()
    {
        gameover = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit()
    {
        Application.Quit();
    }
}
