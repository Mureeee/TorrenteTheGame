using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class volverSalaCasa : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D objecteTocat)
    {
        Debug.Log("Colisi�n detectada con: " + objecteTocat.gameObject.name);
        if (objecteTocat.gameObject.tag == "sala")
        {
            SceneManager.LoadScene("casa");
        }
    }   
}