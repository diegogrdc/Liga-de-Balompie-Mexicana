using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombieraycast : MonoBehaviour
{
    // Variables para gestionar el radio de visión, el de ataque y la velocidad
    public float visionRadius;
    public float attackRadius;
    public float speed;

    // Variable para guardar al jugador
    GameObject player;

    // Variable para guardar la posición inicial
    Vector3 initialPosition;

    // Animador y cuerpo cinemático con la rotación en Z congelada
    //Animator anim;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
         // Guardamos nuestra posición inicial
        initialPosition = transform.position;
        
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Por defecto nuestro target siempre será nuestra posición inicial
        Vector3 target = initialPosition;
         // Comprobamos un Raycast del enemigo hasta el jugador
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position, 
            player.transform.position - transform.position, 
            visionRadius, 
            1 << LayerMask.NameToLayer("Default") 
                // Poner el propio Enemy en una layer distinta a Default para evitar el raycast
                // También poner al objeto Attack y al Prefab Slash una Layer Attack 
                // Sino los detectará como entorno y se mueve atrás al hacer ataques
        );

        // Aquí podemos debugear el Raycast
        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);


        // Si el Raycast encuentra al jugador lo ponemos de target
        if (hit.collider != null) {
            if (hit.collider.tag == "Player"){
                target = player.transform.position;
            }
        }

        // Calculamos la distancia y dirección actual hasta el target
        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;

     // Si es el enemigo y está en rango de ataque nos paramos y le atacamos
       if (target != initialPosition && distance < attackRadius){
            // Aquí le atacaríamos, pero por ahora simplemente cambiamos la animación
            //anim.SetFloat("movX", dir.x);
            //anim.SetFloat("movY", dir.y);
            //anim.Play("Enemy_Walk", -1, 0);  // Congela la animación de andar
        }
        // En caso contrario nos movemos hacia él
        else {
            rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);

            // Al movernos establecemos la animación de movimiento
            /*anim.speed = 1;
            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
            anim.SetBool("walking", true);*/
        }

        // Una última comprobación para evitar bugs forzando la posición inicial
        if (target == initialPosition && distance < 0.02f){
            transform.position = initialPosition; 
            // Y cambiamos la animación de nuevo a Idle
           // anim.SetBool("walking", false);
        }
        Debug.DrawLine(transform.position, target, Color.green);
    }
        // Podemos dibujar el radio de visión y ataque sobre la escena dibujando una esfera
        void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);

    }

}
