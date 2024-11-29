using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class volverAFuera : MonoBehaviour
{
    public void VolverAlJuego()
    {
        // Cambia de vuelta a la escena principal
        SceneManager.LoadScene("fuera");
    }
}
