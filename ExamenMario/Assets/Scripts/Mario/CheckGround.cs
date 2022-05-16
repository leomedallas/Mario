using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool isGrounded;
    public bool marioDies = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true; //Booleano que checa si Mario esta tocando el suelo

        if(collision.transform.CompareTag("Void"))
        {
            marioDies = true; //Si Mario toca el vacío activamos su muerte
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false; //Booleano que checa si Mario no esta tocando el suelo
    }
}
