using UnityEngine;

public class Settings : MonoBehaviour
{

    [SerializeField] GameObject SettingsMenu;
    public void Setting()
    {
        SettingsMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseSettings()
    {
        SettingsMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AudioSettings()
    {
        if (AudioListener.volume >= 1f)
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = 1f;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
