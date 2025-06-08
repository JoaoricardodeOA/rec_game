using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveX;
    private CapsuleCollider2D colliderPlayer;
    private Vector3 startPosition;

    public float speed = 5f;
    public int maxJumps = 2;
    private int remainingJumps;

    public bool isGrounded;
    public float jumpForce = 10f;
    public int life;
    public TextMeshProUGUI textLife;

    private bool jumpQueued = false;

    // 🎧 Áudio
    private AudioSource audioSource;

    public AudioClip jumpClip;
    public AudioClip hurtClip;
    public AudioClip walkClip1;
    public AudioClip walkClip2;
    public AudioClip landOnGroundClip;
    public AudioClip landOnEnemyClip;
    public AudioClip collectableClip;
    public AudioClip deathClip;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        remainingJumps = maxJumps;
        colliderPlayer = GetComponent<CapsuleCollider2D>();
        startPosition = transform.position;

        // 🎧 Inicializa o componente de áudio
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpQueued = true;
        }

        moveX = Input.GetAxisRaw("Horizontal");
        textLife.text = life.ToString();

        if (life <= 0)
        {
            colliderPlayer.enabled = false;
            PlayDeath();
        }

        if (transform.position.y < -50)
        {
            Debug.Log("It's over");
            Reset();
        }
    }

    void FixedUpdate()
    {
        Move();
        HandleJumping();
    }

    void HandleJumping()
    {
        if (jumpQueued)
        {
            if (isGrounded)
            {
                remainingJumps = maxJumps - 1;
                Jump();
            }
            else if (remainingJumps > 0)
            {
                remainingJumps--;
                Jump();
            }
            jumpQueued = false;
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        PlayJump();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            PlayLandOnGround();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayLandOnEnemy();
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
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

        if (moveX < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            PlayWalk();
        }
        if (moveX > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            PlayWalk();
        }
    }

    void Reset()
    {
        transform.position = startPosition;
        life = 5;
        colliderPlayer.enabled = true;
    }

    // 🔊 Métodos de som
    void PlayJump() => PlayClip(jumpClip);
    void PlayHurt() => PlayClip(hurtClip);
    void PlayWalk()
    {
        AudioClip walkClip = Random.value < 0.5f ? walkClip1 : walkClip2;
        PlayClip(walkClip);
    }
    void PlayLandOnGround() => PlayClip(landOnGroundClip);
    void PlayLandOnEnemy() => PlayClip(landOnEnemyClip);
    void PlayCollectable() => PlayClip(collectableClip);
    void PlayDeath() => PlayClip(deathClip);

    void PlayClip(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
