using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Instancia �nica del GameManager (Singleton)
    public static GameManager instance;

    // Variables globales que puedes compartir entre escenas
    public Vector3 posicionJugador = Vector3.zero;
    public string escenaAnterior = "";

    // M�todo que se ejecuta al cargar este objeto
    private void Awake()
    {
        // Si la instancia a�n no est� asignada, la asignamos
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Evita que se destruya al cargar nuevas escenas
        }
        else
        {
            Destroy(gameObject); // Destruye este objeto si ya existe una instancia
        }
    }

    // Ejemplo de c�mo puedes resetear datos globales (opcional)
    public void ResetGameManager()
    {
        posicionJugador = Vector3.zero;
        escenaAnterior = "";
    }
}
