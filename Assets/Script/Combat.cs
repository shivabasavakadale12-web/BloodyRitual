using UnityEngine;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{
    bool Attacking = false;
    Animator animator;
    BoxCollider2D HitBox;

    void Start()
    {
        Debug.Log("Combat script started");
        animator = GetComponent<Animator>();
        HitBox = GetComponentInChildren<BoxCollider2D>();
        HitBox.enabled = false;
    }

    public void OnActionAttack(InputAction.CallbackContext context)
    {
        if (context.performed && !Attacking)
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
