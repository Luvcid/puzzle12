using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float jumpPower;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private LayerMask Waterlayer;
    //[SerializeField] private AudioClip walkSound;
    //[SerializeField] private AudioClip jumpSound; // new audio clip for jumping
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private bool isFacingRight = true;
    private bool Grounded;
    public bool canMove = true;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(HorizontalInput * speed, body.velocity.y);

        if (HorizontalInput > 0.02f)
        {
            if (!isFacingRight)
            {
                Flip();
            }
            //PlayWalkSound();
        }
        else if (HorizontalInput < -0.02f)
        {
            if (isFacingRight)
            {
                Flip();
            }
            //PlayWalkSound();
        }

        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            Jump();
            //PlayJumpSound(); // play the jump sound when the player jumps
        }

        anim.SetBool("Run", HorizontalInput != 0);
        anim.SetBool("Grounded", Grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        anim.SetTrigger("Jump");
        Grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Grounded = true;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundlayer);
        return raycastHit.collider != null;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    /*private void PlayWalkSound()
    {
        if (walkSound != null && Grounded)
        {
            AudioSource.PlayClipAtPoint(walkSound, transform.position);
        }
    }

    private void PlayJumpSound()
    {
        if (jumpSound != null)
        {
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        }
    }*/
}



/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float jumpPower;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private LayerMask Waterlayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private bool isFacingRight = true;
    private bool Grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(HorizontalInput * speed, body.velocity.y);

        if (HorizontalInput > 0.02f)
        {
            if (!isFacingRight)
            {
                Flip();
            }
        }
        else if (HorizontalInput < -0.02f)
        {
            if (isFacingRight)
            {
                Flip();
            }
        }

        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            Jump();
        }

        anim.SetBool("Run", HorizontalInput != 0);
        anim.SetBool("Grounded", Grounded);
    }

    private void Jump()
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("Jump");
            Grounded = false;
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            Grounded = true;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundlayer);
        return raycastHit.collider != null;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
*/