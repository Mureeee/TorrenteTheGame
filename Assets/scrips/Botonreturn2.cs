using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonReturn2 : MonoBehaviour
{
    public void pantallaReturn2()
    {
        SceneManager.LoadScene("casa");
    }
    public void pantallaReturn3()
    {
        SceneManager.LoadScene("cofre");
    }

    public void volveraljuego()
    {
        SceneManager.LoadScene("sala2");
    }

    public void salir()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

