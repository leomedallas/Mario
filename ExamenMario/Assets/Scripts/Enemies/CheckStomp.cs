using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStomp : MonoBehaviour
{
    public int HP;
    private int currentHP;
    public bool goombaIsDead;
    public Goomba goomba;
    public Mario mario;

    private void Start()
    {
        currentHP = HP;
        goombaIsDead = false;
    }

    private void Update()
    {
        if(currentHP == 0) //Su HP es igual a 0 cuando Mario lo aplasta porque Mario quita 1 HP 
        {
            mario.IncreaseScore(200); //Si checa que toco los pies de Mario aumentamos el contador de puntaje
            goombaIsDead = true; //Activa el bool que detecta si el Goomba murió
            goomba.mustMove = false; //Desactiva el movimiento del Goomba
            transform.parent.GetComponent<Animator>().SetBool("Die", true); //Activa la animación de muerte del Goomba
            Destroy(transform.parent.gameObject, .2f); //Destruye al Goomba en 0.2s
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage; //Resta la cantidad de damage que los pies de Mario manda a la función
    }
}
