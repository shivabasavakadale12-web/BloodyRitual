using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    PlayerLane playerLane;
    Vector2 Movement;
    Rigidbody2D rb;
    SpriteRenderer SR;
    Animator animator;
    bool Facingleft;

    void Start()
    {
        playerLane = GetComponent<PlayerLane>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
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
        if (!playerLane.OnTop)
        {
            SR.flipX = Facingleft;
        }
        else
        {
            SR.flipX = !Facingleft;
        }

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
