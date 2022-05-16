using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScnManager : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //Si se presiona espacio se cambia la escena al intro del nivel
        {
            SceneManager.LoadScene("LevelIntro");
        }
    }
}
