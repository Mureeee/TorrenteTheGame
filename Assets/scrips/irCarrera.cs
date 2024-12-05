using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class irCarrera : MonoBehaviour
{
    public bool puedeAbrirCoche = false;
    public GameObject TextC;
    // Start is called before the first frame update
    void Start()
    {
        TextC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (puedeAbrirCoche && Input.GetKeyDown(KeyCode.E))
        {
            // Cambiar a la siguiente escena
            SceneManager.LoadScene("Huida");
            TextC.SetActive(true);
        }
    }

    public void OnCollisionEnter2D(Collision2D objecteTocat)
    {
        if (objecteTocat.gameObject.tag == "cochejg")
        {
            TextC.SetActive(true);
            puedeAbrirCoche = true;
        }
    }

    public void OnCollisionExit2D(Collision2D objecteTocat)
    {
        if (objecteTocat.gameObject.tag == "cochejg")
        {
            TextC.SetActive(false);
            puedeAbrirCoche = false;
        }
    }
}
