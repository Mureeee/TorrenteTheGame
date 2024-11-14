using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonVolverInicio : MonoBehaviour
{
    // Start is called before the first frame update
    public void volverinicio()
    {
        SceneManager.LoadScene("Inicio");
    }
}
