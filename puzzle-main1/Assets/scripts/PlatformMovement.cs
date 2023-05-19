using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public bool isVerticallyControlled;
    //public AudioClip moveSound;

    private bool isBeingControlled = false;
    private Rigidbody2D rb;

    //private AudioSource audioSource;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //audioSource = GetComponent<AudioSource>();
        //audioSource.clip = moveSound;
    }

    public void StartControlling()
    {
        isBeingControlled = true;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (isVerticallyControlled)
        {
            rb.constraints |= RigidbodyConstraints2D.FreezePositionX;
        }
        else
        {
            rb.constraints |= RigidbodyConstraints2D.FreezePositionY;
        }
    }

    public void StopControlling()
    {
        isBeingControlled = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void FixedUpdate()
    {
        if (isBeingControlled)
        {
            if (isVerticallyControlled)
            {
                float verticalInput = Input.GetAxis("Vertical");
                rb.velocity = new Vector2(rb.velocity.x, verticalInput * 5f);
            }
            else
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                rb.velocity = new Vector2(horizontalInput * 5f, rb.velocity.y);
            }
            // if (!audioSource.isPlaying)
            {
               // audioSource.Play();
            }
        }
        else
        {
            //audioSource.Stop();
        }
    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public bool isVerticallyControlled;

    private bool isBeingControlled = false;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void StartControlling()
    {
        isBeingControlled = true;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (isVerticallyControlled)
        {
            rb.constraints |= RigidbodyConstraints2D.FreezePositionX;
        }
        else
        {
            rb.constraints |= RigidbodyConstraints2D.FreezePositionY;
        }
    }

    public void StopControlling()
    {
        isBeingControlled = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void FixedUpdate()
    {
        if (isBeingControlled)
        {
            if (isVerticallyControlled)
            {
                float verticalInput = Input.GetAxis("Vertical");
                rb.velocity = new Vector2(rb.velocity.x, verticalInput * 5f);
            }
            else
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                rb.velocity = new Vector2(horizontalInput * 5f, rb.velocity.y);
            }
        }
    }
}
*/