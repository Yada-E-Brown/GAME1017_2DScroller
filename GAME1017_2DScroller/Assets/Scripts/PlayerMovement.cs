using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    public float runningVelocity = 2f;
    public float jumpForce = 10f;        
    public float jumpHoldMultiplier = 10f; 
    public float maxJumpHoldTime = 1f;

    private bool isGrounded;
    private bool isJumping;
    private float jumpTimeCounter;
    public TMP_Text PositionText;
    public TMP_Text SpeedText;
    private float uiUpdateTimer = 0f;
    public float uiUpdateInterval = 1f;
    private float speedMultiplier = 1f;
    private float slowTimer = 0f;
    public float slowDuration = 1f;


  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Start jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            anim.SetTrigger("jump");
            anim.SetBool("isGrounded", false);
        }

        //  higher jump
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter < maxJumpHoldTime)
            {
                rb.linearVelocity += new Vector2(0, jumpForce * jumpHoldMultiplier * Time.deltaTime);
                jumpTimeCounter += Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if (transform.position.y <= -5f)
        {
            GameManager.Instance.GameOver();
        }
        if (slowTimer > 0)
        {
            slowTimer -= Time.deltaTime;

            if (slowTimer <= 0)
            {
                speedMultiplier = 1f;
            }
        }
        uiUpdateTimer += Time.deltaTime;

        if (uiUpdateTimer >= uiUpdateInterval)
        {
            uiUpdateTimer = 0f;

            PositionText.text = "Position: " + transform.position.x.ToString("F2");

            float speed = rb.linearVelocity.magnitude;
            SpeedText.text = "Speed: " + speed.ToString("F2");
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(runningVelocity * speedMultiplier, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }
        anim.SetBool("isGrounded", true);
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            anim.SetBool("isGrounded", false);
        }
    }
    public void Slow(float amount)
    {
        speedMultiplier = amount;
        slowTimer = slowDuration;

    }
    public void IncreaseSpeed(float amount, float maxCap)
    {
        speedMultiplier += amount;
        speedMultiplier = Mathf.Min(speedMultiplier, maxCap);
    }
}