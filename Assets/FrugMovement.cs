using UnityEngine;

public class FrugMovement : MonoBehaviour
{
    private float speed = 6f;
    private float jumpForce = 6.5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    public ScoreManager scoreManager;
    public GameOver gameOver;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(6.51f, 6.51f, 6.51f);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-6.51f, 6.51f, 6.51f);
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Melon"))
        {
            Destroy(other.gameObject);
            scoreManager.IncreaseScore();
            if (!AreThereAnyMelonsLeft())
            {

                Debug.Log("All melons collected!");

                int finalScore = scoreManager.GetScore();
                gameOver.ShowVictory(finalScore);
            }
        }

        if (other.gameObject.CompareTag("Danger"))
        {
            scoreManager.DecreaseScore();
            if (scoreManager.GetScore() < 0)
            {
                gameOver.ShowGameOver(0);
            }
        }
    }

    bool AreThereAnyMelonsLeft()
    {
        GameObject[] melons = GameObject.FindGameObjectsWithTag("Melon");
        return melons.Length > 2;
    }
}
