using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float velocity = 10;
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
    }
}