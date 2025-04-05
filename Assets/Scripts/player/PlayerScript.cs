using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveX;
    private CapsuleCollider2D colliderPlayer;
    private Vector3 startPosition;  // To store the starting position


    public float speed = 5f;
    public int maxJumps = 2; // Max number of jumps
    private int remainingJumps; // Jumps left in the air

    public bool isGrounded;
    public float jumpForce = 10f;
    public int life;
    public TextMeshProUGUI textLife;

    private bool jumpQueued = false; // To track the jump button press and queue it up

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        remainingJumps = maxJumps; // Set the remaining jumps at the start
        colliderPlayer = GetComponent<CapsuleCollider2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Queue up a jump if the button is pressed
        if (Input.GetButtonDown("Jump"))
        {
            jumpQueued = true;
            
        }
        
        // Update horizontal movement input
        moveX = Input.GetAxisRaw("Horizontal");

        textLife.text = life.ToString();

        if(life <= 0 ){
            colliderPlayer.enabled = false;
        }
        if(transform.position.y < -50)
        {
            Debug.Log("It's over");
            Reset();
        }
    }

    void FixedUpdate()
    {
        // Apply horizontal movement
        Move();
        

        // Handle jumping
        HandleJumping();
    }

    void HandleJumping()
    {
        // If we have a queued jump and we're either grounded or have air jumps left
        if (jumpQueued)
        {
            if (isGrounded)
            {
                // Reset jump count when grounded
                remainingJumps = maxJumps - 1; // Subtract 1 because we're using one jump now
                Jump();
                
            }
            else if (remainingJumps > 0)
            {
                // Air jump
                remainingJumps--;
                Jump();
                jumpQueued = false;
            }
            jumpQueued = false; 
        }
        
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply the jump force on the Y-axis
    }

    void OnCollisionEnter2D(Collision2D collision)
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
    void Move()
    {
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        if(moveX<0)
        {
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        if(moveX>0)
        {
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
    }
    void Reset(){
        transform.position = startPosition;
        life = 5;
        colliderPlayer.enabled = true;
    }
}