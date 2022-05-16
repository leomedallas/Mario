using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed;
    public bool canMove;
    public bool marioStar;

    private Rigidbody2D rb;
    public int jumpPower = 10;

    public CheckGroundStar checkGroundStar;

    public float timeRemaining;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeRemaining = 8f;
        marioStar = false;
    }

    private void Update()
    {

        if(canMove) //Hace que la estrella se mueva a la derecha
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }
        else //Hace que la estrella se mueva a la izquierda
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }

        if(checkGroundStar.isGrounded) //Si la estrella esta tocando el suelo puede saltar
        {
            Jump();
        }

        if (timeRemaining > 0) //Si el tiempo que dura la estrella es mayor a 0 se va restando segundo por segundo
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (timeRemaining <= 1) //Si el tiempo llega a 0 la estrella se destruye
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Mario")) //Si toca a Mario se activa el bool que detecta si Mario tiene la estrella y la estrella se destruye
        {
            marioStar = true;
            Destroy(gameObject, 0.2f);
        }
    }

    private void Jump() //Función que hace que la estrella salte
    {
        rb.velocity = Vector2.up * jumpPower;
    }
}
