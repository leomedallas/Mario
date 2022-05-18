using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    public bool mustMove;
    public float walkSpeed = 3.0f;
    public CheckGround check;
    public CheckStompKoopa koopa;

    private void OnBecameVisible()
    {
        enabled = true; //Se activa el GameObject cuando una cámara lo este viendo 
    }

    private void OnBecameInvisible()
    {
        enabled = false; //Se desactiva el GameObject cuando una cámara no lo este viendo
    }

    private void Start()
    {
        mustMove = true;
    }

    void Update()
    {
        if(mustMove)
        {
            transform.Translate(-2 * walkSpeed * Time.deltaTime, 0, 0); //Este bool hace que el Goomba se mueva a la izquierda
        }
        
        if(check.marioDies)
        {
            mustMove = false; //Se desactiva cuando Mario muere
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Pipe") || collision.transform.CompareTag("Goomba") || (collision.gameObject.CompareTag("Koopa") && koopa.currentHP == 2))
        {
            Flip(); 
        }

        if(collision.transform.CompareTag("Void"))
        {
            Destroy(gameObject); //Si choca con el vacío se destruye
        }

        if(collision.gameObject.CompareTag("Koopa") && koopa.currentHP == 1)
        {
            Destroy(gameObject); //Si choca con un Koopa cuando esta en el estado de caparazón se destruye
        }
    }

    void Flip()
    {
        mustMove = false; //Deja de moverse para poder cambiar de dirección y luego se mueve otra vez
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustMove = true;
    }
}
