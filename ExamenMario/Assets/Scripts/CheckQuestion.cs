using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckQuestion : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject coin;
    public Mario mario;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Mario"))
        {
            mario.IncreaseCoins(); //Si checa que toco a Mario aumentamos el contador de monedas
            mario.IncreaseScore(100); //Si checa que toco a Mario aumentamos el contador de puntaje
            audioSource.Play();
            coin.gameObject.SetActive(true); //Si checa que toco a Mario activa al GameObject Coin
            StartCoroutine("Bump");
        }
    }

    IEnumerator Bump() //Con esta corutina logramos el efecto de que el bloque suba cuando Mario lo golpea y que luego se destruya
    {
        transform.parent.localPosition = new Vector2(transform.parent.localPosition.x, transform.parent.localPosition.y + 0.1f); //Sube la posición en y del papá
        yield return new WaitForSeconds(0.08f); //Espera 0.08s
        transform.parent.localPosition = new Vector2(transform.parent.localPosition.x, transform.parent.localPosition.y - 0.1f); //Baja la posición en y del papá
        yield return new WaitForSeconds(audioSource.clip.length); //Espera la duración del efecto de sonido
        coin.gameObject.SetActive(false); //Desactiva el GameObject Coin
        Destroy(transform.parent.gameObject); //Destruye el bloque
    }
}
