using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerHitBox"))
        {
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
