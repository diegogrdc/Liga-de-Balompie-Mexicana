﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{

    static public float speed = 0.1f;
    
    public Animator anim;

    void Update() {
        if( transform.position.x < -2.0 ) {
            speed = 0.1f;
            anim.SetFloat("Horizontal",1);
        }
        if( transform.position.x > 8.0 ) {
            speed = -0.1f;
            anim.SetFloat("Horizontal",-1);
        }
        transform.position += new Vector3( speed , 0.000f , 0.0000f );

    }

}
