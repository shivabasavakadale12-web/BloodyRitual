using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] Enemydata Enemydata;
    [SerializeField] BoxCollider2D hitBox; 

     GameObject Sister;
    Transform player;
    PlayerLane playerLane;
    Rigidbody2D Rb;
    Animator Animator;

    bool isAttacking;
    float coolDown;

    void Start()
    {
        Sister = GameObject.FindWithTag("Sister");
        GameObject p = GameObject.FindWithTag("Player");
        player = p.transform;
        playerLane = p.GetComponent<PlayerLane>();
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        hitBox.enabled = false;
    }

    void Update()
    {
        if (isAttacking) { Stop(); return; }


        coolDown += Time.deltaTime;

        float moveDir = Mathf.Sign(Sister.transform.position.x - transform.position.x);

        if(player == null) { Chase(moveDir); return; }

        if (PlayerBlocking(moveDir))
        {
            Stop();
            if (coolDown >= Enemydata.attackFrequency) StartAttack();
            return;
        }

        Chase(moveDir);
    }

    bool PlayerBlocking(float moveDir)
    {
        if (playerLane.OnTop) return false;            
        float dx = player.position.x - transform.position.x;
        bool ahead = Mathf.Sign(dx) == moveDir;          
        return ahead && Mathf.Abs(dx) <= Enemydata.attackRange;
    }

    void Chase(float moveDir)
    {
        Rb.linearVelocity = new Vector2(moveDir * Enemydata.speed, 0f);
        Animator.SetBool("Run", true);
        transform.rotation = Quaternion.Euler(0f, moveDir > 0 ? 0f : 180f, 0f);
    }

    void Stop()
    {
        Rb.linearVelocity = Vector2.zero;
        Animator.SetBool("Run", false);
    }

    void StartAttack()
    {
        isAttacking = true;
        coolDown = 0f;
        Animator.SetTrigger("Attack");
    }

    void AttackHitBox() { hitBox.enabled = true; }

    void AttackHitBoxEnd()
    {
        isAttacking = false;
        hitBox.enabled = false;
    }
}