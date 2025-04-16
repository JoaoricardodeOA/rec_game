using UnityEngine;
using System.Threading.Tasks;

public class tilemover : MonoBehaviour
{
    private CapsuleCollider2D colliderKeeper;
    private bool goRight;
    public float speed;


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
private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
            if (contact.normal.y == -1f)
                {
                    collision.transform.Translate(Vector3.right * speed * Time.deltaTime);
                    Debug.Log("teste");
                }
            }

            
        }
    }
}
