using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    EnemyDeadState enemyDead;

    bool ishurt = false;
    private void Start()
    {
       enemyDead = GetComponent<EnemyDeadState>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ishurt) return;
        ishurt = true;
        if (collision.gameObject.CompareTag("PlayerHitBox"))
        {
            enemyDead.EnemyDead(ishurt);
        }
    }

    public void die()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }   
}
