using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Mario"))
        {
            Destroy(gameObject, 0.01f); //Se destruye si dedtecta que Mario lo tocó
        }
    }
}
