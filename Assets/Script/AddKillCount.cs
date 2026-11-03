using TMPro;
using UnityEngine;

public class AddKillCount : MonoBehaviour
{
  [SerializeField] TMPro.TMP_Text killcount;
  public GameObject SlashEffect;
    int count;

    public void AddCount(int kill)
    {
        count += kill;
        killcount.text = count.ToString("00");
        
        Debug.Log("Kills : " + count);
    }
}
