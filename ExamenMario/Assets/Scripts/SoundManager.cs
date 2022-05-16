using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] clips;
    public CheckGround check;
    public Mario mario;
    public Star star;
    public StageClear clear;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[0];
        audioSource.Play();
    }


    void Update()
    {
        if (check.marioDies || mario.timesUp) //Si Mario muere o se acaba el tiempo se inicia la corutina
        {
            StartCoroutine("MarioDies");
        }

        if(clear.stageClear)
        {
            StartCoroutine("StageClear"); //Si Mario completa el nivel se inicia la corutina
        }
    }

    IEnumerator MarioDies() //Se pausa la música se cambia el clip a la nueva, se espera la duración de la música y desactiva el bool
    {
        audioSource.Pause();
        audioSource.clip = clips[1];
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.Stop();
        check.marioDies = false;
    }

    IEnumerator StageClear() //Se pausa la música se cambia el clip a la nueva, se espera la duración de la música y pasa el nivel
    {
        audioSource.Pause();
        audioSource.clip = clips[2];
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.Stop();
    }
}
