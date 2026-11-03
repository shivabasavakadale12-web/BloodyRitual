using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{

    AddKillCount addKillCount;

    private void Start()
    {
        addKillCount = FindAnyObjectByType<AddKillCount>();

    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            addKillCount.AddCount(1);
            Instantiate(addKillCount.SlashEffect, collision.transform.position, Quaternion.identity);
        }
        
    }
}
