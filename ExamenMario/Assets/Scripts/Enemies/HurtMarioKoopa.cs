using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtMarioKoopa : MonoBehaviour
{
    public CheckGround check;
    public Koopa koopa;
    public Star star;
    public Mario mario;
    public CheckStompKoopa hp;
    public GameObject parent;

    private void Start()
    {
        mario = FindObjectOfType<Mario>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Mario") && hp.currentHP == 2 && !star.marioStar && !mario.isGrow) //Si choca con Mario, el Koopa tiene 2 HP y Mario no tiene la estrella, se deja de mover y activa el bool que detecta que Mario muere
        {
            koopa.mustMove = false;
            check.marioDies = true;
        }

        if (collision.transform.CompareTag("Mario") && !star.marioStar && mario.isGrow)
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
