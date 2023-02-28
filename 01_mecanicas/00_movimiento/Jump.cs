using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBehaviour : MonoBehaviour
{
    Rigidbody2D rb; //variable para almacenar el componente rigidbody2D
    public float speed;
    public float jumpSpeed;

    bool jumped;

    [SerializeField] LayerMask capasuelo;

    float tiempoEnElAire;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); //almacenamos el componente Rigidbody2D 
    }

    void Update() 
    {
        //Mover al jugador hacia los lados con "A", "D" y las flechas direccionales.
        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y, 0);

        //Raycast hacia abajo
        RaycastHit2D raycastFloor = Physics2D.Raycast(transform.position, Vector2.down, 0.25f, capasuelo);

        if (raycastFloor == true) {
            tiempoEnElAire = 0;
            jumped = false;
        } else {
            //Sumar tiempo al contador
            tiempoEnElAire += Time.deltaTime;
        }

        //Saltar al puslar "Espacio"
        if ((Input.GetButtonDown("Jump"))&&(jumped=false)) { //si pulsamos el boton de saltar
            jumped = true;
            if(raycastFloor == true) { //y esta tocando el suelo
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed); //saltamos
                rayCastFloor = false; //y dejamos de tocar el suelo
            } else { //ya no estaba tocando
                if (tiempoEnElAire < 0.25f) { //todavia puede saltar
                    rb.velocity = new Vector2(rb.velocity.x, jumpSpeed); //saltamos
                    rayCastFloor = false; //seguimos sin tocar el suelo
                } else {
                    //NADA
                }
            } 
        }
    }
}