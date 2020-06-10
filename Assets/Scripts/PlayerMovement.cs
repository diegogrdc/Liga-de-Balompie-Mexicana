using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    
    public Rigidbody2D rb;

    public Animator anim;

    public bool alive = true;

    public bool touchingWall = false;

    Vector2 movement;

    void Update()
    {
        if (alive) {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if(!touchingWall) movement = movement.normalized;

            if (movement != Vector2.zero) {
                anim.SetFloat("Horizontal", movement.x);
                anim.SetFloat("Vertical", movement.y);
                anim.SetBool("Walking", true);
            } else {
                anim.SetBool("Walking", false);
            }
        }
        
    }
    void FixedUpdate()
    {
        if (alive) rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Wall"))
            {
                touchingWall = false;
            }
    }

    void OnCollisionEnter2D(Collision2D col) {
        
        if (col.gameObject.CompareTag("Wall"))
            {
                touchingWall = true;
            }
    }

    

    
 

}
