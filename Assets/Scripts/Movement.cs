using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public bool touchingPlatform;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        speed = 5.5F;
        touchingPlatform = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb.velocity;

        /*if (Input.GetKey("up"))
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
            rb.velocity = new Vector2(0, 2);
        }*/
        /*if (Input.GetKey("down"))
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y - (speed * Time.deltaTime));
            rb.velocity = new Vector2(0, -2);
        }*/
        if (Input.GetKey(KeyCode.A))
        {
            //transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            //rb.velocity = new Vector2(-2, 0);
            vel.x = -3;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            //rb.velocity = new Vector2(2, 0);
            vel.x = 3;
        }
        if (Input.GetKeyDown(KeyCode.W) && touchingPlatform )
        {
            //transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            //rb.velocity = new Vector2(0, 2);
            vel.y = 7;
        }
        if (Input.GetKeyUp("down"))
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y - (speed * Time.deltaTime));
            vel.y = -5;
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

}       




