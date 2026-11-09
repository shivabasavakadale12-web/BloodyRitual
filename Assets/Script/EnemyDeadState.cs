using UnityEngine;

public class EnemyDeadState : MonoBehaviour
{
    EnemyAi enemyAi;
    Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject EnemyDeadEffect;
    public bool isWiped = false;
    bool isDead = false;
    private void Start()
    {
        enemyAi = GetComponent<EnemyAi>();
        animator = GetComponent<Animator>();
    }
    void OnEnable()
    {
        RitualTIme.RitualEnded += OnRitualEnded;
    }

    void OnDisable()
    {
        RitualTIme.RitualEnded -= OnRitualEnded;
    }

    void OnRitualEnded()
    {
        Debug.Log("Ritual Ended");
        isWiped = true;
        EnemyDead(true);
    }
    public void EnemyDead(bool ishurt)
    {
        if (isDead) return;
        isDead = true;
        audioSource.Play();
        enemyAi.enabled = false;
        if (isWiped)
        {
            Instantiate(EnemyDeadEffect, transform.position, Quaternion.identity);
            Debug.Log(Instantiate(EnemyDeadEffect, transform.position, Quaternion.identity) + " is the effect");
        }

        else
        {
         Time.timeScale = 0.5f;
        }
        animator.SetTrigger("Die"); 
    }
}
