using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOer : MonoBehaviour
{
    [SerializeField] GameObject LostMenu;
    [SerializeField] Camera Camera;
    [SerializeField] float ZoomSpeed = 50f;
    [SerializeField] float rotateSpeed = 50f;
    float minSize = 3;
    float maxSize = 7;

    private void Start()
    {
        LostMenu.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Camera.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        Camera.orthographicSize -= ZoomSpeed * Time.deltaTime;
        Camera.orthographicSize = Mathf.Clamp(Camera.orthographicSize, minSize, maxSize);

        Debug.Log("game over");
        Time.timeScale = 0.35f;
        StartCoroutine(LoadSceneRoutine());
    }
    IEnumerator LoadSceneRoutine()
    {
        yield return new WaitForSecondsRealtime(2f);
        LostMenu.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit()
    {
        Application.Quit();
    }
}
