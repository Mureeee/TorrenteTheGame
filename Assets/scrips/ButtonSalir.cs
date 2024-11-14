using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSalir : MonoBehaviour
{
    // Start is called before the first frame update
    public void SalirDelJuego()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
    Application.Quit();
    #endif
    }
}
