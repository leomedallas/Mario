using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelIntro : MonoBehaviour
{
    private void Update()
    {
        Invoke("ChangeScene", 2f); //Invoca la funci�n que cambia del intro del nivel a la escena del nivel despu�s de 2s 
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("1-1");
    }
}
