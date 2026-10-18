using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] Enemydata Enemydata;
    Transform player;
    Rigidbody2D Rb;
    Animator Animator;
    BoxCollider2D hitBox;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        hitBox = GetComponentInChildren<BoxCollider2D>();
    }

    void Update()
    {
        if (Enemydata.isAttacking) return;

       Vector2 distance = player.position - transform.position;
        if (distance.magnitude < Enemydata.attackRange)
        {
            Enemydata.isAttacking = true;
            Animator.SetTrigger("Attack");
        }  
        
        else
        {
            Rb.linearVelocity = distance.normalized * Enemydata.speed;
            Rb.MovePosition(Rb.position + distance.normalized * Enemydata.speed * Time.fixedDeltaTime);
            Animator.SetBool("Run", true);
        }
    }

    void AttackHitBox()
    {
        hitBox.enabled = true;
    }

    void AttackHitBoxEnd()
    {
        Debug.Log("AttackHitBoxEnd");
        Enemydata.isAttacking = false;
        hitBox.enabled = false;
    }
}
