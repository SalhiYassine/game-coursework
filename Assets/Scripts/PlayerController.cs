using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float hzInput;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        hzInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(hzInput * speed, body.velocity.y);

        // Handles player changing direction, more specifially the way they are facing
        if (hzInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        
        else if (hzInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Jump logic
     
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }


        // Set animator params
        anim.SetBool("Running", hzInput != 0);
        anim.SetBool("Grounded", isGrounded());
    }
    private void Jump()
    {
        if (isGrounded())
        {

        body.velocity = new Vector2(body.velocity.x, jumpPower);
        anim.SetTrigger("Jump");
        }
    }
 
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    
    public bool canAttack()
    {
        return hzInput == 0 && isGrounded();
    }
}
