using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public float speedModifierOnCollsiion = 0.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collided with player?
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
        //when get compoent fails, it returns null, so it's not a player
        if(player != null)
        {
            player.Slow(speedModifierOnCollsiion);

            if (rb != null)
            {
                rb.gravityScale = 2;
            }
        }

    }
}
