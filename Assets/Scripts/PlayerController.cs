using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float hzInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(hzInput * speed, body.velocity.y);
        // Handles player changing direction, more specifially the way they are facing
        if(hzInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (hzInput < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        // Set animator params
        anim.SetBool("Running", hzInput != 0);
        anim.SetBool("Grounded", grounded);
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("Jump");
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
