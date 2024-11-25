using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casa : MonoBehaviour
{
    public GameObject misterio;
    public GameObject textPorta;
    public GameObject textNada;
    public GameObject textPista;
    public GameObject textVerde;
    public GameObject textCorrecto;
    public GameObject llave;
    public GameObject armario;

    private bool puedeInteractuarMisterio = false;
    private bool puedeInteractuarPista = false;
    private bool puedeInteractuarVerde = false;
    private bool puedeInteractuarCorrecto = false;
    private bool puedeInteractuarArmario = false;
    private bool interactuoConArmario = false;

    // Start is called before the first frame update
    void Start()
    {
        //OCULTARLOS AL INICIO
        textPorta.SetActive(false);
        textNada.SetActive(false);
        textPista.SetActive(false);
        textVerde.SetActive(false);
        textCorrecto.SetActive(false);
        llave.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (puedeInteractuarMisterio && Input.GetKeyDown(KeyCode.E))
        {
            textPorta.SetActive(false);
            textNada.SetActive(true);
            Invoke("noHayNada", 1f);
        }

        if (puedeInteractuarPista && Input.GetKeyDown(KeyCode.E))
        {
            textPista.SetActive(true);
            Invoke("OcultarTextPista", 2f);
        }

        if (puedeInteractuarArmario && Input.GetKeyDown(KeyCode.E))
        {
            interactuoConArmario = true;
            textPorta.SetActive(false);
            textNada.SetActive(true);
            Invoke("noHayNada", 1f);
        }

        if (puedeInteractuarVerde && Input.GetKeyDown(KeyCode.E))
        {
            if (interactuoConArmario)
            {
                textVerde.SetActive(true);
                Invoke("OcultarTextVerde", 2f);
            }
            else
            {
                textNada.SetActive(true);
                Invoke("noHayNada", 1f);
            }
        }

        if (puedeInteractuarCorrecto && Input.GetKeyDown(KeyCode.E))
        {
            textPorta.SetActive(false);
            textCorrecto.SetActive(true);
            llave.SetActive(true);
            Invoke("OcultarTextCorrecto", 3f);
        }
    }
    public void OnCollisionEnter2D(Collision2D objecteTocat)
    {
        //TAG MISTERIO
        if (objecteTocat.gameObject.tag == "misterio")
        {
            textPorta.SetActive(true);
            puedeInteractuarMisterio = true;
        }

        //TAG PISTA
        if (objecteTocat.gameObject.tag == "pista")
        {
            textPorta.SetActive(true);
            puedeInteractuarPista = true;
        }

        //TAG VERDE
        if (objecteTocat.gameObject.tag == "verde")
        {
            textPorta.SetActive(true);
            puedeInteractuarVerde = true;
        }

        //TAG CORRECTO
        if (objecteTocat.gameObject.tag == "correcto")
        {
            textPorta.SetActive(true);
            puedeInteractuarCorrecto = true;
        }

        //OBJETO ARMARIO
        if (objecteTocat.gameObject == armario)
        {
            textPorta.SetActive(true);
            puedeInteractuarCorrecto = true;
        }
     }

    public void OnCollisionExit2D(Collision2D objecteTocat)
    {
        // Cuando el personaje se aleja del objeto "misterio"
        if (objecteTocat.gameObject.tag == "misterio")
        {
            textPorta.SetActive(false);
            puedeInteractuarMisterio = false;
        }

        if (objecteTocat.gameObject.tag == "pista")
        {
            textPorta.SetActive(false);
            puedeInteractuarPista = false;
        }

        if (objecteTocat.gameObject.tag == "verde")
        {
            textPorta.SetActive(false);
            puedeInteractuarVerde = false;
        }

        if (objecteTocat.gameObject.tag == "correcto")
        {
            textPorta.SetActive(false);
            puedeInteractuarCorrecto = false;
        }

        if (objecteTocat.gameObject == armario)
        {
            textPorta.SetActive(false);
            puedeInteractuarArmario = false;
        }

    }

    //MOSTRAR TEXTO INTERACTUAR
    public void interactuar()
    {
        textPorta.SetActive(false);
    }

    //MOSTRAR TEXTO NADA
    public void noHayNada()
    {
        textNada.SetActive(false);
    }

    public void OcultarTextPista()
    {
        textPista.SetActive(false);
    }
    public void OcultarTextVerde()
    {
        textVerde.SetActive(false);
    }
    public void OcultarTextCorrecto()
    {
        textCorrecto.SetActive(false);
    }
}
