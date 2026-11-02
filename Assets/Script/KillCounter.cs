using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    [SerializeField] TMP_Text killcount;
    [SerializeField] GameObject SlashEffect;
    int count;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            count++;
            Instantiate(SlashEffect, collision.transform.position, Quaternion.identity);
            Debug.Log("Kills : " +  count);
            killcount.text = count.ToString("00");
        }
        
    }
}
