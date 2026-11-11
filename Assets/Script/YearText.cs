using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class YearText : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField] TMP_Text yearText;                        
    void Start()
    {
        levelManager = LevelManager.Instance;
        yearText.text = "Year: " + levelManager.GetCurrentYear.ToString("00");
        yearText.alpha = 0f;
        StartCoroutine(SceneLoadRoutine());
    }

    System.Collections.IEnumerator SceneLoadRoutine()
    {
         yield return new WaitForSeconds(1f);
         yearText.alpha = 1f;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("RitualRoom");
    }
}
