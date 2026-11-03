using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    Animator Animator;
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyHitBox"))
        {
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
