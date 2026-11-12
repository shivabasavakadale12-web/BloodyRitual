using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    EnemyDeadState enemyDead;
    EnemyAi enemyai;
    bool ishurt = false;
    public bool isHurt => ishurt;
    private void Start()
    {
       enemyDead = GetComponent<EnemyDeadState>();
        enemyai = GetComponent<EnemyAi>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ishurt) return;
        if (collision.gameObject.CompareTag("PlayerHitBox"))
        {
            ishurt = true;
            enemyai.Stopall();
            enemyai.enabled = false;
            enemyDead.EnemyDead(ishurt);
            Invoke("die", 0.7f);
        }
    }

    public void die()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }   
}
