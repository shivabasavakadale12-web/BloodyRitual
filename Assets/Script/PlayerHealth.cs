using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Combat combat;
    [SerializeField] AudioSource audioSource;
    Animator Animator;
    bool isHurt = false;
    public bool Hurt => isHurt;
    void Start()
    {
        combat = GetComponent<Combat>();
        Animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyHitBox") && !combat.isAttacking)
        {
            isHurt = true;
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(audioSource.clip, cameraPos);
            Time.timeScale = 0.35f;
            Animator.SetTrigger("Hurt");
        }
    }

    void Die()
    {
        Destroy(gameObject);

    }
}
