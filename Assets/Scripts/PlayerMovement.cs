using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public GameObject blood;

    
    public Rigidbody2D rb;

    public Animator anim;

    public bool alive = true;

    Vector2 movement;

    void Update()
    {
        if (alive) {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            movement = movement.normalized;

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

    void OnTriggerEnter2D(Collider2D other) 
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Pickup"))
            {
                other.gameObject.SetActive(false);
            }
    }

    void OnCollisionEnter2D(Collision2D col) {
        
        if (col.gameObject.CompareTag("Enemy"))
            {
                Instantiate(blood, transform.position, Quaternion.identity);
                alive = false;
                anim.SetBool("Dead", true);
                StartCoroutine(GameOver());
            }
    }

    IEnumerator GameOver() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameOver");
    }

    
 

}
