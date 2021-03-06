using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHead : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mario")) 
        {
            audioSource.Play();
            StartCoroutine("Bump"); //Si detecta que toco a Mario iniciamos la Corutina Bump
        }
    }

    IEnumerator Bump() //Con esta corutina logramos el efecto de que el bloque es golpeado por Mario cuando es peque?o
    {
        transform.parent.localPosition = new Vector2(transform.parent.localPosition.x, transform.parent.localPosition.y + 0.1f); //Sube la posici?n en y del pap?
        yield return new WaitForSeconds(0.1f); //Espera 0.1s
        transform.parent.localPosition = new Vector2(transform.parent.localPosition.x, transform.parent.localPosition.y - 0.1f); //Baja la posici?n en y del pap?
    }
}
