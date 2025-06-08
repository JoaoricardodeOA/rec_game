using UnityEngine;

public class PernaCAbeluda : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public float speed = 2f;
    private Transform player;
    private bool playerInZone = false;
    private CapsuleCollider2D colliderKeeper;

    private Rigidbody2D rb; 
    void Start()
    {
        colliderKeeper = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetPlayerInZone(bool inZone, Transform playerTransform)
    {
        playerInZone = inZone;
        player = playerTransform;
    }

    void Update()
    {
        if (playerInZone && player != null)
        {
            Vector3 newPosition = transform.position;

            if (player.position.x > transform.position.x)
            {
                newPosition.x += speed * Time.deltaTime;
                transform.eulerAngles = new Vector3(0f,0f,0f);
            }
            else if (player.position.x < transform.position.x)
            {
                newPosition.x -= speed * Time.deltaTime;
                transform.eulerAngles = new Vector3(0f,180f,0f);
            }

            transform.position = newPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.transform.position.y > transform.position.y + colliderKeeper.size.y)
            {
                rb.gravityScale = 1f; 
                rb.linearVelocity = new Vector2(0, -5f);
                Destroy(this.gameObject,2f);

            }
            else
            {
                
                collider.GetComponent<PlayerScript>().life--;
            }
            Debug.Log(collider.transform.position.y + "  "  +transform.position.y);
        }
    }
}
