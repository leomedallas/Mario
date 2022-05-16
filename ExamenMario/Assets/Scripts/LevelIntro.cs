using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelIntro : MonoBehaviour
{
    private void Update()
    {
        Invoke("ChangeScene", 2f); //Invoca la función que cambia del intro del nivel a la escena del nivel después de 2s 
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("1-1");
    }
}
