using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    public Mario mario;
    public bool stageClear;

    private void Start()
    {
        stageClear = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Mario"))
        {
            mario.canMove = false;
            stageClear = true;
            Invoke("WinGame", 5.641f);
        }
    }

    void WinGame()
    {
        SceneManager.LoadScene("Win");
    }
}
