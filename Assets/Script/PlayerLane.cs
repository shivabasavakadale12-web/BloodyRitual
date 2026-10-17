using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLane : MonoBehaviour
{
    [SerializeField] float bottomY = -1.72f;
    [SerializeField] float topY = 0.18f;
    [SerializeField] float topDuration = 4f;
    [SerializeField] float cooldown = 0.5f;
    Rigidbody2D rb;
    SpriteRenderer sr;
    bool onTop;
    float topTimer;
    float cooldownTimer;

    public bool OnTop => onTop;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (cooldownTimer > 0f) cooldownTimer -= Time.deltaTime;

        if (!onTop) return;

        topTimer -= Time.deltaTime;
        if (topTimer <= 0f) GoBottom();
    }

    public void OnLaneUp(InputAction.CallbackContext context)
    {
        if (context.performed) GoTop();
    }

    public void OnLaneDown(InputAction.CallbackContext context)
    {
        if (context.performed) GoBottom();
    }

    void GoTop()
    {
        if (onTop || cooldownTimer > 0f) return;

        onTop = true;
        topTimer = topDuration;
        SnapTo(topY, 180f);
    }

    void GoBottom()
    {
        if (!onTop) return;

        onTop = false;
        cooldownTimer = cooldown;
        SnapTo(bottomY, 0f);
    }
    void SnapTo(float y, float angle)
    {
        rb.position = new Vector2(rb.position.x, y);
        rb.rotation = angle;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
    }
}