using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOer : MonoBehaviour
{
    [SerializeField] GameObject LostText;
    [SerializeField] GameObject LostMenu;
    [SerializeField] Camera Camera;
    [SerializeField] DestroyObjects sister;
    [SerializeField] DestroyObjects player;
    [SerializeField] GrayscaleEffect effect;
    [SerializeField]
    GameObject FireEffect;
    [SerializeField] float ZoomSpeed = 50f;
    [SerializeField] float rotateSpeed = 50f;
    float minSize = 3;
    float maxSize = 7;
    bool gameover = false;

    private void Start()
    {
        LostMenu.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
    IEnumerator LoadSceneRoutine(Collider2D collision)

    {
        effect.EnableGrayscale();
        yield return new WaitForSecondsRealtime(1);
        if (collision != null)
        {
            sister.OnDestroy();
            FireEffect.SetActive(true);
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
