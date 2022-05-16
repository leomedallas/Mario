using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audioSource;

    public float bounceForce;

    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("HurtBox")) //Si los pies de Mario chocan con la cabeza del Goomba le envia 1 HP menos a la función del Goomba y le da un pequeño bounce a Mario
        {
            collision.gameObject.GetComponent<CheckStomp>().TakeDamage(1);
            rb.AddForce(transform.up * bounceForce * Time.deltaTime, ForceMode2D.Impulse);
            audioSource.Play();
        }
        
        if(collision.gameObject.CompareTag("HurtBoxKoopa")) //Si los pies de Mario chocan con la cabeza del Koopa le envia 1 HP menos a la función del Koopa y le da un pequeño bounce a Mario
        {
            collision.gameObject.GetComponent<CheckStompKoopa>().TakeDamage(1);
            rb.AddForce(transform.up * bounceForce * Time.deltaTime, ForceMode2D.Impulse);
            audioSource.Play();
        }
    }
}
