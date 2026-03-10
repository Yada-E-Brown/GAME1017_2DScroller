using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float runningVelocity = 2f;
    public float jumpForce = 10f;        // initial jump force
    public float jumpHoldMultiplier = 2f; // extra lift when holding
    public float maxJumpHoldTime = 0.2f;

    private bool isGrounded;
    private bool isJumping;
    private float jumpTimeCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Start jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // single impulse
        }

        // Hold jump for slightly higher jump
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter < maxJumpHoldTime)
            {
                rb.linearVelocity += new Vector2(0, jumpForce * jumpHoldMultiplier * Time.deltaTime);
                jumpTimeCounter += Time.deltaTime;
            }
        }

        // Stop holding jump
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if (transform.position.y <= -5f)
        {
            GameManager.GetInstance().GameOver();
        }
    }

    void FixedUpdate()
    {
        if (GameManager.GetInstance().GetMode() == GameManager.States.Play)
        {
            rb.linearVelocity = new Vector2(runningVelocity, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}