using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie33 : MonoBehaviour
{

    static public float speed = 0.02f,last;
    
    public Animator anim;

    public Rigidbody2D rb;

    public float Right;
    public float Left;

    void Update() {
        if(Time.timeScale == 0)
        speed = 0;

        if( transform.position.x < Left && Time.timeScale == 1) {
            speed = 0.02f;
            last = speed;
            anim.SetFloat("Horizontal",1);
        }
        if( transform.position.x > Right && Time.timeScale == 1) {
            speed = -0.02f;
            last = speed;
            anim.SetFloat("Horizontal",-1);
        }

        if(transform.position.x > Left && transform.position.x < Right && Time.timeScale == 1){
            if(last > 0){
                anim.SetFloat("Horizontal",1);
            }
            if(last < 0){
                anim.SetFloat("Horizontal",-1);
            }
            speed = last;
        }

        transform.position += new Vector3( speed , 0.000f , 0.0000f );
    }
}


