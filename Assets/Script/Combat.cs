using UnityEngine;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{
    EnemyAi enemyAttack;
    bool Attacking = false;
    public bool isAttacking => Attacking;
    Animator animator;
    BoxCollider2D HitBox;
    [SerializeField] AudioSource swordSwing;
    [SerializeField] GameObject effect;
    bool isEffectActive = false;

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
        if (context.performed && !Attacking )
        {
          
            Attack();
        }
    }

    public void OnActionAttack2(InputAction.CallbackContext context)
    {
        if (context.performed && !Attacking && !isEffectActive)
        {
            isEffectActive = true;
            Instantiate(effect, transform.position,transform.rotation * Quaternion.Euler(0,180,0) * Quaternion.Euler(90, 0, 0));
            Attacking = true;
            animator.SetTrigger("Attack2");
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(swordSwing.clip, cameraPos);

        }
    }
    void Attack()
    {
         Attacking = true;
         animator.SetTrigger("Attack");
         Vector3 cameraPos = Camera.main.transform.position;
         AudioSource.PlayClipAtPoint(swordSwing.clip, cameraPos);
    }

    void EnableHitBox()
    {
        HitBox.enabled = true;
    }

    void DisableHitBox()
    {
        isEffectActive = false;
        HitBox.enabled = false;
        Attacking = false;
    }
}
