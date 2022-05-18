using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Mario : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;
    private SpriteRenderer sprRndr;
    private Animator anim;
    public CapsuleCollider2D coll;
    public CheckGround check;
    private AudioSource audioSource;
    [Header("Movement")]
    public float runSpeed = 2;
    public bool canMove;
    [Header("Jump")]
    public float jumpForce = 3;
    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    [Header("Objects")]
    public int coins;
    public Star star;
    public bool isGrow;
    public bool isFlower;
    [Header("Time")]
    public int time;
    public float timeRemaining; 
    public float starTimeRemaining;
    public bool timesUp;
    [Header("Score")]
    public int score;
    [Header("Misc")]
    public AudioClip[] clips;
    public TMP_Text txtCoin, txtScore, txtTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprRndr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        canMove = true; //Bool que hace que Mario se puede mover o no
        timesUp = false; //Bool que detecta cuando el tiempo se acabó
        isGrow = false;
        isFlower = false;
        coins = 0; //Contador de monedas
        score = 0; //Contador de puntaje
        timeRemaining = 401; //Tiempo restante del nivel
        starTimeRemaining = 8f; //Tiempo que Mario dura con la estrella
    }

    private void Update()
    {
        txtTime.text = time.ToString(); //Muestra en el UI el tiempo restante

        if (timeRemaining > 0) //Si el tiempo restante es mayor a 0 se resta segundo por segundo y transforma el valor del tiempo restante de float a int para el UI
        {
            timeRemaining -= Time.deltaTime; 
            time = (int)timeRemaining;
        }
        else if (timeRemaining <= 1) //Si el tiempo llega a 0 se activa el bool que indica que se acabo el tiempo
        {
            timesUp = true;
        }

        if (starTimeRemaining > 0 && star.marioStar) //Si el tiempo que Mario tiene la estrella es mayor a 0 y Mario tiene la estrella se resta segundo a segundo
        {
            starTimeRemaining -= Time.deltaTime;
        }
        else if (starTimeRemaining <= 1 && star.marioStar) //Si el tiempo de la estrella llega a 0 se activa el bool que indica que Mario ya no posee la estrella
        {
            star.marioStar = false;
        }

        if (check.marioDies) //Si Mario muere se cambia la escena con la duración de la música
        {
            Invoke("GameOver", 2.712f);
        }

        if (timesUp) //Si se acaba el tiempo se cambia la escena con la duración de la música
        {
            Invoke("TimeUp", 2.712f);
        }

        if (star.marioStar) //Si Mario tiene la estrella se activa la animación de la estrella
        {
            anim.SetBool("IsStar", true);
        }
        else if (!star.marioStar) //Si Mario no tiene la estrella se desactiva la animación de la estrella
        {
            anim.SetBool("IsStar", false);
        }

        if(isGrow)
        {
            anim.SetBool("Grow", true);
            coll.offset = new Vector2(0.01149f, 0.2354f);
            coll.size = new Vector2(0.4141f, 0.9709f);
        }
        else if(!isGrow)
        {
            anim.SetBool("Grow", false);
        }

        if(isFlower)
        {
            anim.SetBool("IsFlower", true);
            coll.offset = new Vector3(0.01149f, 0.2354f, 0f);
            coll.size = new Vector3(0.4141f, 0.9709f, 0f);
        }
        else if (!isFlower)
        {
            anim.SetBool("IsFlower", false);
        }

        if(!isGrow && !isFlower)
        {
            coll.offset = new Vector2(0.00119f, 0.00030f);
            coll.size = new Vector2(0.24942f, 0.50069f);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) && canMove)  //Mueve a Mario a la derecha con D y activa la animación de correr
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            sprRndr.flipX = false;
            anim.SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.A) && canMove) //Mueve a Mario a la izquierda con A y activa la animación de correr
        {
            rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
            sprRndr.flipX = true;
            anim.SetBool("Run", true);
        }
        else //Si no se presiona ninguna tecla Mario permance quieto
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetBool("Run", false);
        }

        if (Input.GetKey(KeyCode.Space) && check.isGrounded && canMove) //Si se presiona la tecla espacio y Mario esta tocando el suelo, Mario salta y se reproduce el sonido de salto
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            audioSource.clip = clips[0];
            audioSource.Play();
        }

        if(Input.GetKey(KeyCode.E) && isFlower)
        {
            audioSource.clip = clips[2];
            audioSource.Play();
            anim.SetBool("IsThrow", true);
        }
        else
        {
            anim.SetBool("IsThrow", false);
        }

        if (!check.isGrounded) //Si el personaje no esta tocando el suelo se activa la animación de salto y se desactiva la de correr
        {
            anim.SetBool("Jump", true);
            anim.SetBool("Run", false);
        }

        if (check.isGrounded) //Si el personaje esta tocando el suelo se desactiva la animación de salto y se activa la de correr
        {
            anim.SetBool("Jump", false);
        }

        if (check.marioDies || timesUp) //Si se acaba el tiempo Mario deja de moverse y se activa la animación de muerte y Mario se desactiva después de la duración del sonido de muerte
        {
            canMove = false;
            anim.SetBool("Die", true);
            Invoke("Death", 2.712f);
        }

        if (betterJump) 
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime; //Si el jugador hace un salto prolongado el valor de la caída es el normal
            }
            if (rb.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime; //Si el jugador hace un salto corto el valor de la caída es menor
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Mushroom"))
        {
            Physics2D.IgnoreCollision(collision.collider, coll);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin")) //Si Mario choca con una moneda el contador de monedas aumenta y se activa el sonido de la moneda
        {
            audioSource.clip = clips[1];
            audioSource.Play();
            IncreaseScore(100);
            IncreaseCoins();
        }

        if (collision.gameObject.CompareTag("Mushroom")) 
        {
            audioSource.clip = clips[3];
            audioSource.Play();
            isGrow = true;
            Destroy(collision.gameObject, 0.2f);
        }

        if (collision.gameObject.CompareTag("Flower") && isGrow)
        {
            audioSource.clip = clips[3];
            audioSource.Play();
            isFlower = true;
            Destroy(collision.gameObject, 0.2f);
        }
    }

    public void IncreaseCoins()
    {
        txtCoin.text = "x " + coins.ToString(); //Muestra en el UI las monedas
        coins = coins + 1;
    }

    public void IncreaseScore(int _score)
    {
        txtScore.text = score.ToString(); //Muestra en el UI el puntaje
        score = score + _score;
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    void TimeUp()
    {
        SceneManager.LoadScene("TimeUp");
    }

    void Death()
    {
       gameObject.SetActive(false);
    }
}
