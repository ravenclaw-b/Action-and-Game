using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update

    float jumpForce = 10f;
    public Rigidbody2D rb;
    public bool isGrounded = false;
    public float speed = .2f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

    float horizontalInput = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }


    // Ground check
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }   
    }
    // !Ground check
    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }   
    }
}