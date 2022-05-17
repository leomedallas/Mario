using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public bool mustMove;
    public bool isGrow;
    public float walkSpeed = 1.0f;

    public CheckGround check;

    private void Start()
    {
        isGrow = false;
        mustMove = true; //Se desactiva cuando Mario muere
    }

    void Update()
    {
        if (mustMove)
        {
            transform.Translate(walkSpeed * Time.deltaTime, 0, 0); //Este bool hace que el Koopa se mueva a la izquierda
        }

        if (check.marioDies)
        {
            mustMove = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Pipe") || collision.transform.CompareTag("Goomba"))
        {
            Flip(); //Si choca con una tubería o con otro Koopa o Goomba se mueve hacía el lado contrario de este
        }

        if (collision.transform.CompareTag("Void"))
        {
            Destroy(gameObject); //Si choca con el vacío se destruye
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Mario")) //Si toca a Mario se activa el bool que detecta si Mario tiene la estrella y la estrella se destruye
        {
            isGrow = true;
            Destroy(gameObject, 0.2f);
        }
    }

    void Flip()
    {
        mustMove = false; //Deja de moverse para poder cambiar de dirección y luego se mueve otra vez
        walkSpeed *= -1;
        mustMove = true;
    }
}
