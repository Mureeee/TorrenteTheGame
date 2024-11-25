using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cofre : MonoBehaviour
{
    public GameObject cofreCerrado;
    public GameObject textPorta;
    public GameObject textPortaLlave;
    public GameObject textPortaPortal;
    public bool puedeAbrirCofre = false; // Cambio: Controlar si el jugador está junto al cofre
    public bool puedeUsarLlave = false; // Cambio: Controlar si el jugador puede usar la llave
    public GameObject cofreAbierto;
    public GameObject llaveCasa;
    public GameObject portal;

    void Start()
    {
        if (cofreAbierto != null) cofreAbierto.SetActive(false);
        if (llaveCasa != null) llaveCasa.SetActive(false);
        if (portal != null) portal.SetActive(false);
    }

    void Update()
    {
        // Abrir el cofre solo si el jugador está cerca y presiona E
        if (puedeAbrirCofre && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(cofreCerrado);
            Invoke("activarCofre", 0f);
            puedeAbrirCofre = false; // Impedir que el cofre se abra nuevamente
        }

        // Usar la llave solo si el jugador está cerca y presiona E
        if (puedeUsarLlave && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(llaveCasa);
            textPortaPortal.SetActive(true);
            Invoke("interactuar3", 3.5f);
            Invoke("activarPortal", 0f);
            puedeUsarLlave = false; // Impedir que la llave se use nuevamente
        }
    }

    void OnCollisionEnter2D(Collision2D objecteTocat)
    {
        if (objecteTocat.gameObject.tag == "cofre")
        {
            textPorta.SetActive(true);
            Invoke("interactuar", 0.5f);
            puedeAbrirCofre = true; // Permitir abrir el cofre
        }
        else if (objecteTocat.gameObject.tag == "cofreAbierto")
        {
            textPortaLlave.SetActive(true);
            Invoke("interactuar2", 2.5f);
        }
        else if (objecteTocat.gameObject.tag == "llave")
        {
            textPorta.SetActive(true);
            Invoke("interactuar", 0.5f);
            puedeUsarLlave = true; // Permitir usar la llave
        }
    }

    void OnCollisionExit2D(Collision2D objecteTocat)
    {
        // Cambio: Resetear estados cuando el jugador sale del área de colisión
        if (objecteTocat.gameObject.tag == "cofre")
        {
            puedeAbrirCofre = false;
        }
        else if (objecteTocat.gameObject.tag == "llave")
        {
            puedeUsarLlave = false;
        }
    }

    public void interactuar()
    {
        textPorta.SetActive(false);
    }

    public void interactuar2()
    {
        textPortaLlave.SetActive(false);
    }

    public void interactuar3()
    {
        textPortaPortal.SetActive(false);
    }

    public void activarCofre()
    {
        if (cofreAbierto != null) cofreAbierto.SetActive(true);
        if (llaveCasa != null) llaveCasa.SetActive(true);
    }

    public void activarPortal()
    {
        if (portal != null) portal.SetActive(true);
    }
}
