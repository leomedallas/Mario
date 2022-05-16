using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGroundStar : MonoBehaviour
{
    public bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground")) //Booleano que checa si la estrella solo toca el suelo con el tag Ground
            isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //Booleano que checa si la estrella no toca el suelo con el tag Ground
            isGrounded = false;
    }
}
