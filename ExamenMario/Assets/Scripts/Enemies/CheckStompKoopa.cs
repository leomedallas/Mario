using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStompKoopa : MonoBehaviour
{
    public int HP;
    public int currentHP;
    public bool goombaIsDead;
    public Koopa koopa;
    public Mario mario;

    private void Start()
    {
        currentHP = HP;
        goombaIsDead = false;
    }

    private void Update()
    {
        if (currentHP == 0) //Su HP es igual a 0 cuando Mario lo aplasta porque Mario quita 1 HP 
        {
            mario.IncreaseScore(200); //Si checa que toco los pies de Mario aumentamos el contador de puntaje
            goombaIsDead = true; //Activa el bool que detecta si el Koopa murió (Nota: utilicé el mismo bool que el Goomba para no complicarme la vida con otro bool xD)
            Destroy(transform.parent.gameObject, .2f); //Destruye al koopa en 0.2s
        }

        if(currentHP == 1) //El Koopa a diferencia del Goomba tiene 2 de HP, para que el Koopa pueda entrar al estado del caparazón cuando los pies de Mario le resten 1 HP
        {
            koopa.mustMove = false; //Desactiva el movimiento del Koopa
            transform.parent.GetComponent<Animator>().SetBool("Die", true); //Activa la animación cuando el Koopa se convierte en un caparazón
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage; //Resta la cantidad de damage que los pies de Mario manda a la función
    }
}
