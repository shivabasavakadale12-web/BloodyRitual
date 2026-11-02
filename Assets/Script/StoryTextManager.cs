using TMPro;
using UnityEngine;

public class StoryTextManager : MonoBehaviour
{
    [SerializeField] TMP_Text storyTextUI;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject StartButton;
    [SerializeField] AudioSource onclick1Audio;
    [SerializeField] AudioSource onclick2Audio;
    string[] storyText = new string[]
    {
        "Long ago, our family killed a fourteen year old girl to protect its honor." +
        " As she died, she cursed us. She swore she would return every " +
        "fourteen years, reborn, to hunt us. She keeps her word.",

        "Her curse holds a trap whoever tries to end it falls into it" +
        ". So we do not try. Every fourteen years," +
        " my sister performs the ritual that holds her back, and it begins again.",

        "Tonight the dead return. Nothing may cross the circle. Not them. Not me." +
        " Protect my sister, and hold the line for as long as you can."
    };


    void Start()
    {
        nextButton.SetActive(true);
        StartButton.SetActive(false);
        storyTextUI.text = storyText[0];
    }
    public void Nextbutton()
    {
        if (storyTextUI.text == storyText[0])
        {    storyTextUI.text = storyText[1];
            onclick1Audio.Play();
        }
        else if (storyTextUI.text == storyText[1])
        {
            storyTextUI.text = storyText[2];
            StartButton.SetActive(true);
            nextButton.SetActive(false);
            onclick2Audio.Play();
        }
    }

    public void StartButton_Click()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

}
