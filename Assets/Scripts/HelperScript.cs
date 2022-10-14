using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript : MonoBehaviour
{

    LayerMask floorLayerMask;
    Color hitColour;
    float raylength;

    void Start()
    {
        floorLayerMask = LayerMask.GetMask("Floor");
    }

    public void DoRayCollisionCheck()
    {
        float rayLength = 1.0f;

        //cast a ray downward of length 1
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {

            if (hit.collider.tag == "Enemy")
            {
                print("Player has collided with Enemy");
                hitColor = Color.red;
            }

            if (hit.collider.tag == "Floor")
            {
                print("Player has collided with Floor");
                hitColor = Color.green;
            }
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position, -Vector2.up * rayLength, hitColor);

    }
    public void FlipObject(bool flip)
        {
            // get the SpriteRenderer component
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

            if (flip == true)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
}
