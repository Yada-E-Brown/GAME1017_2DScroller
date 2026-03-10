using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float velocity = 10;

    public float jumpForce = 12f;
    public float jumpHoldForce = 6f;
    public float maxJumpHoldTime = 0.25f;

    private float jumpTimer;
    private bool isJumping;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.GetInstance().GetMode() == GameManager.States.Play)
        {
            rb.linearVelocity = new Vector2(velocity, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
        if (GameManager.GetInstance().playerCharacter.transform.position.y <= -5.0f)
        {
            GameManager.GetInstance().GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            jumpTimer = maxJumpHoldTime;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimer > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y + jumpHoldForce * Time.fixedDeltaTime);
                jumpTimer -= Time.fixedDeltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}