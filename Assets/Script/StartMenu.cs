using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] TMP_Text starttext;
    [SerializeField] AudioSource onclickAudio;
    bool stopsflash = false;
    void Start()
    {
        Time.timeScale = 1f;
        Debug.Log("StartMenu initialized");
    }
    public void StartButton()
    {
        Debug.Log("Start button clicked");
        StartCoroutine(ButtonclickRoutin());
    }

    IEnumerator ButtonclickRoutin()
    {
        onclickAudio.Play();
        yield return new WaitForSeconds(2f);
        stopsflash = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void Update()
    {
        if (stopsflash) return;

        StartCoroutine(FlashText());
    }

    IEnumerator FlashText()
    {
        while(true)
        {
            starttext.alpha = Mathf.PingPong(Time.time, 0.9f);
            yield return new WaitForSeconds(0.3f);
            starttext.alpha = Mathf.PingPong(Time.time, 1f);
        }
    }
}
