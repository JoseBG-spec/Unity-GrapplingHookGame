using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //private Animator an;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private bool moving;
    public float moveSpeed, jumpVelocity;
    public int numJumps;
    public Collision coll;
    public Vector3 initalPos;
    public AudioSource death;
    // Start is called before the first frame update
    void Start()
    {
        //an = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        moving = false;
        initalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(x, y);
        Walk(dir);

        if (Input.GetKeyDown(KeyCode.W) && numJumps > 0)
        {
            //an.SetBool("Jumping", true);
            Jump(Vector2.up);
            numJumps--;
        }
        if (coll.onGround)
        {
            //an.SetBool("Jumping", false);
            numJumps = 1;
        }

    }
    private void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpVelocity;
    }
    private void Walk(Vector2 dir)
    {
        if (dir.x != 0)
        {
            //an.SetBool("Running", true);
            moving = true;
        }
        else
        {
            //an.SetBool("Running", false);
            moving = false;
        }
        if (moving)
        {
            rb.velocity = new Vector2(dir.x * moveSpeed, rb.velocity.y);
            if (dir.x < 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (dir.x > 0)
            {
                spriteRenderer.flipX = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("o");
        if (collision.gameObject.tag == "lava" || collision.gameObject.tag=="Enemy")
        {
            //Debug.Log("o");
            death.Play();
            transform.position = initalPos;
        }
        if (collision.gameObject.tag == "End")
        {

        }
    }
}
   
    
