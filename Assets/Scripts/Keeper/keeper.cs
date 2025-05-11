using UnityEngine;
using System.Threading.Tasks;

public class keeper : MonoBehaviour
{
    private CapsuleCollider2D colliderKeeper;
    private bool goRight;

    public int life;
    public float speed;
    public bool collidedWithPlayer = false;


    private Rigidbody2D rb;  // Rigidbody2D component for applying gravity

    public Transform a;
    public Transform b;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colliderKeeper = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(goRight)
        {
            if(Vector2.Distance(transform.position, b.position) < 0.5f)
            {
                goRight = false;
            }

            transform.eulerAngles = new Vector3(0f,0f,0f);
            transform.position = Vector2.MoveTowards(transform.position,b.position,speed * Time.deltaTime);
        }
        else
        {
            if(Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                goRight = true;
            }
            transform.eulerAngles = new Vector3(0f,180f,0f);
            transform.position = Vector2.MoveTowards(transform.position,a.position,speed * Time.deltaTime);
        }

        
    }
   void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.transform.position.y > transform.position.y + colliderKeeper.size.y)
            {
                
                rb.gravityScale = 1f; 
                rb.velocity = new Vector2(0, -5f);
                Destroy(this.gameObject,2f);

            }
            else
            {
                
                collider.GetComponent<PlayerScript>().life--;
            }
            collidedWithPlayer = true;

            Debug.Log(collider.transform.position.y + "  "  +transform.position.y);
        }
    }

}
