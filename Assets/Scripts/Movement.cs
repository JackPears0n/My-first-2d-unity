using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
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
    int health;

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
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {

        CheckForLanding();
        CheckForWalkLeft();
        CheckForWalkRight();

        Vector2 vel = rb.velocity;
        anim.SetBool("walk", false);
        anim.SetBool("jump", false);

        // check for walk left button
        if (Input.GetKey(KeyCode.A))
                {
                    vel.x = -3;
                    anim.SetBool("walk", true);
                }

        // check for walk right button

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
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

        // check for jumpflag
        if (isJumping == true)
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

    // destroy object
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
        }
    }
}




