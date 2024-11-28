using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class volverSalaCasa : MonoBehaviour
{
    public GameObject textPorta;
    public void OnCollisionEnter2D(Collision2D objecteTocat)
    {
        if (objecteTocat.gameObject.tag == "casa")
        {
            SceneManager.LoadScene("casa");
        }
        if (objecteTocat.gameObject.tag == "texto")
        {
            textPorta.SetActive(true);
            Invoke("mostrarTexto", 2f);
        }
    }  

    public void mostrarTexto()
    {
        textPorta.SetActive(false);
    }
}