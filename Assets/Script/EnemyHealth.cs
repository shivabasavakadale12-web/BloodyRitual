using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    EnemyAi enemyAi;
    Animator animator;

    private void Start()
    {
        enemyAi = GetComponent<EnemyAi>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerHitBox"))
        {
            enemyAi.enabled = false;
            Time.timeScale = 0.5f;
            animator.SetTrigger("Die");
        }
    }

    public void die()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }   
}
