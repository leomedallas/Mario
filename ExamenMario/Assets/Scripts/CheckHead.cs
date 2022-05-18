using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHead : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] clips;
    public Mario mario;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mario = FindObjectOfType<Mario>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mario")) 
        {
            audioSource.clip = clips[0];
            audioSource.Play();
            StartCoroutine("Bump"); //Si detecta que toco a Mario iniciamos la Corutina Bump
        }
        if((collision.CompareTag("Mario") && mario.isGrow) || (collision.CompareTag("Mario") && mario.isFlower))
        {
            audioSource.clip = clips[1];
            audioSource.Play();
            Destroy(transform.parent.gameObject, 0.547f);
        }
    }

    IEnumerator Bump() //Con esta corutina logramos el efecto de que el bloque es golpeado por Mario cuando es pequeño
    {
        transform.parent.localPosition = new Vector2(transform.parent.localPosition.x, transform.parent.localPosition.y + 0.1f); //Sube la posición en y del papá
        yield return new WaitForSeconds(0.1f); //Espera 0.1s
        transform.parent.localPosition = new Vector2(transform.parent.localPosition.x, transform.parent.localPosition.y - 0.1f); //Baja la posición en y del papá
    }
}
