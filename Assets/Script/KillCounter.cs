using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    [SerializeField] TMP_Text killcount;

    int count;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            count++;
            Debug.Log("Kills : " +  count);
            killcount.text = count.ToString("00");
        }
        
    }
}
