using UnityEngine;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{
    PlayerHealth health;
    LevelManager levelManager;
    EnemyAi enemyAttack;
    bool Attacking = false;
    public bool isAttacking => Attacking;
    Animator animator;
    BoxCollider2D HitBox;
    [SerializeField] AudioSource swordSwing;
    [SerializeField] GameObject effect;
    bool isEffectActive = false;
    float cooldown = 0f;

    void Start()
    {
        health = GetComponent<PlayerHealth>();
        levelManager = LevelManager.Instance;
        enemyAttack = FindAnyObjectByType<EnemyAi>();
        animator = GetComponent<Animator>();
        HitBox = GetComponentInChildren<BoxCollider2D>();
        HitBox.enabled = false;
    }

    public void OnActionAttack(InputAction.CallbackContext context)
    {
        if (context.performed && !Attacking && !health.Hurt)
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

     void Update()
    {
        if(!Attacking) { return; }

        if(Attacking)
        {
            cooldown += Time.deltaTime;

          if(cooldown >= levelManager.CurrentLevel.playerAttackCooldown)
          {
            cooldown = 0;
            Attacking = false;
          }
        }
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
