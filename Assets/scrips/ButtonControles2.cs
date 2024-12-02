using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControles2 : MonoBehaviour
{
    public GameObject grupomenupausa;
    public GameObject torrente;
    // Start is called before the first frame update
    public void anaraControls2()
    {
        SceneManager.LoadScene("ControlesEnPartida");
    }
    public void anaraControls3()
    {
        SceneManager.LoadScene("ControlesEnCasa");
    }
    public void anaraControls4()
    {
        VariablesGlobales.posTorrenteGuardada = transform.position;
        SceneManager.LoadScene("ControlesFuera");
    }
    public void anaraControls5()
    {
        SceneManager.LoadScene("ControlesCofre");
    }
    public void VolverAlJuego()
    {
        // Cambia de vuelta a la escena principal
        SceneManager.LoadScene("fuera");
    }
}
