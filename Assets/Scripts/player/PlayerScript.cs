using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveX;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal"); // Update moveX with user input
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // Set the new velocity with updated moveX
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }
}
