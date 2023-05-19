 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private void Awake() 
    {
       body = GetComponent<Rigidbody2D>();
      anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {
        
        float HorizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(HorizontalInput  * speed, body.velocity.y);
        
        if (HorizontalInput > 0.02f)
            transform.localScale =new Vector3(1, 1, 1);
        else if (HorizontalInput < -0.02f)
            transform.localScale = new  Vector3(-1, 1, 1);

            anim.SetBool("run", HorizontalInput != 0);
    }
    }
