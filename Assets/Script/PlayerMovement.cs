using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    PlayerLane playerLane;
    Vector2 Movement;
    Rigidbody2D rb;
    Animator animator;
    bool Facingleft;
    float timer = 0f;

    void Start()
    {
        playerLane = GetComponent<PlayerLane>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void OnActionMovement(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();

        if (Movement.x < 0)
        {
          Facingleft = true;
        }

        if (Movement.x > 0)
        {
            Facingleft = false;
        }

        Debug.Log("Movement: " + Movement);
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer >= 30f)
        {
            speed += 0.3f;
        }

        float zAngle = playerLane.OnTop ? 180f : 0f;
        float yAngle = (Facingleft != playerLane.OnTop) ? 180f : 0f;
        transform.rotation = Quaternion.Euler(0f, yAngle, zAngle);
        if (Movement != Vector2.zero)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        Vector2 currentposition = rb.position;
       Vector2 MoveTowards = currentposition + Movement * speed * Time.fixedDeltaTime;
       rb.MovePosition(MoveTowards);
    }


}
