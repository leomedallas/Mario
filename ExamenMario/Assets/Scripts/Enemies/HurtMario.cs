using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtMario : MonoBehaviour
{
    public CheckGround check;
    public Goomba goomba;
    public Star star;
    public Mario mario;
    public CheckStomp checkStomp;
    public GameObject parent;

    private void Start()
    {
        mario = FindObjectOfType<Mario>();
    }

    private void Update()
    {
        if(checkStomp.goombaIsDead)
        {
            this.gameObject.SetActive(false); //Si detecta que el Goomba murió desactiva al Goomba
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Mario") && !star.marioStar && !mario.isGrow) //Si choca con Mario y Mario no tiene la estrella y esta chiquito, se deja de mover y activa el bool que detecta que Mario muere
        {
            goomba.mustMove = false;
            check.marioDies = true;
            Debug.Log("Entre");
        }

        if(collision.transform.CompareTag("Mario") && !star.marioStar && mario.isGrow)
        {
            mario.isGrow = false;
        }

        if (collision.transform.CompareTag("Mario") && star.marioStar) //Si choca con Mario y Mario tiene la estrella destruye al Goomba
        {
            Destroy(parent);
        }

        if (collision.transform.CompareTag("Mario") && star.marioStar && mario.isGrow) //Si choca con Mario y Mario tiene la estrella destruye al Goomba
        {
            Destroy(parent);
        }
    }
}
