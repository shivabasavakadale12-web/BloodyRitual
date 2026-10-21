using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Animator Animator;
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyHitBox"))
        {
            Time.timeScale = 0.35f;
            Animator.SetTrigger("Hurt");
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
