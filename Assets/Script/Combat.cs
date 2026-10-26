using UnityEngine;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{
    EnemyAi enemyAttack;
    bool Attacking = false;
    public bool isAttacking => Attacking;
    Animator animator;
    BoxCollider2D HitBox;

    void Start()
    {
        Debug.Log("Combat script started");
        enemyAttack = FindAnyObjectByType<EnemyAi>();
        animator = GetComponent<Animator>();
        HitBox = GetComponentInChildren<BoxCollider2D>();
        HitBox.enabled = false;
    }

    public void OnActionAttack(InputAction.CallbackContext context)
    {
        if (context.performed && !Attacking && !enemyAttack.IsAttacking)
        {
            Debug.Log("Attack");
            Attack();
        }
    }

    void Attack()
    {
        Attacking = true;
        animator.SetTrigger("Attack");
    }

    void EnableHitBox()
    {
        HitBox.enabled = true;
    }

    void DisableHitBox()
    {
        HitBox.enabled = false;
        Attacking = false;
    }
}
