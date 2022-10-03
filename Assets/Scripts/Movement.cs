using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public bool touchingPlatform;
    private Animator anim;
    bool isJumping;
    bool isWalkingLeft;
    bool isWalkingRight;
    bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        speed = 5.5F;
        touchingPlatform = false;
        anim = GetComponent<Animator>();

        isJumping = false;
        isWalkingLeft = false;
        isWalkingRight = false;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {

        CheckForLanding();
        CheckForWalkLeft();
        CheckForWalkRight();
        CheckForAttack();


        Vector2 vel = rb.velocity;
        anim.SetBool("walk", false);
        anim.SetBool("jump", false);
        anim.SetBool("attack", false);

        // check for walk left button
        if (Input.GetKey(KeyCode.A))
                {
                    vel.x = -3;
                    anim.SetBool("walk", true);
           
                }

        // check for walk right button

        if (Input.GetKey(KeyCode.D))
                {
                    vel.x = 3;
                    anim.SetBool("walk", true);
                }

        // check for jump button
        if (Input.GetKeyDown(KeyCode.W) && touchingPlatform )
                {
                    isJumping=true;

                    vel.y = 7;
                    anim.SetBool("walk", false);
        
                }
        

        // check for attack input
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("attack", true);
        }
        
        
        // check for attackflag
        if (isAttacking == true)
        {
            anim.SetBool("attack", true);
        }
        else
        {
            anim.SetBool("attack", false);
        }

        // check for jumpflag
        if( isJumping==true)
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }

        rb.velocity = vel;

    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingPlatform = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingPlatform = false;
        }
    }


    void CheckForLanding()
    {
        // check for player landing on a platform
        if ((isJumping == true) && touchingPlatform && rb.velocity.y <= 0)
        {
            isJumping = false;
        }
    }

    void CheckForWalkLeft()
    {
        // check for player walking left
        if (Input.GetKey(KeyCode.A))
        {
            isWalkingLeft = false;
        }
    }

    void CheckForWalkRight()
    {
        // check for player walking right
        if (Input.GetKey(KeyCode.D))
        {
            isWalkingRight = false;
        }
    }

    void CheckForAttack()
    {
        // check for left mouse click
        if (Input.GetMouseButton(0))
        {
            isAttacking = true;
        }
    }

}




