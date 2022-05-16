using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStar : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject star;
    public Mario mario;

    public bool starOut;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mario"))
        {
            mario.IncreaseScore(300);
            audioSource.Play();
            star.gameObject.SetActive(true); //Activa el GameObject Star
            StartCoroutine("Bump"); 
        }
    }

    IEnumerator Bump() //Con esta corutina logramos el efecto de que el bloque suba cuando Mario lo golpea, que salga la estrella del bloque y que luego se destruya
    {
        transform.parent.localPosition = new Vector2(transform.parent.localPosition.x, transform.parent.localPosition.y + 0.1f); //Sube la posición en y del papá
        yield return new WaitForSeconds(0.08f); //Espera 0.08s
        transform.parent.localPosition = new Vector2(transform.parent.localPosition.x, transform.parent.localPosition.y - 0.1f); //Baja la posición en y del papá
        yield return new WaitForSeconds(audioSource.clip.length); //Espera la duración del efecto de sonido
        Destroy(transform.parent.gameObject); //Destruye el bloque
    }
}
