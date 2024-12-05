using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject puertacasa;
    public GameObject volver;
    public GameObject TextoInicio;

    private bool puedeInteractuarMisterio = false;
    private bool puedeInteractuarPista = false;
    private bool puedeInteractuarVerde = false;
    private bool puedeInteractuarCorrecto = false;
    private bool puedeInteractuarArmario = false;
    private bool interactuoConArmario = false;
    private bool llaveEncontrada = false;
    private bool puedeRecogerLlave = false;

    // Start is called before the first frame update
    void Start()
    {
        TextoInicio.SetActive(true);
        Invoke("quitexin", 5f);
        // Ocultar elementos al inicio
        textPorta.SetActive(false);
        textNada.SetActive(false);
        textPista.SetActive(false);
        textVerde.SetActive(false);
        textCorrecto.SetActive(false);
        llave.SetActive(false);
        puertacasa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (puedeRecogerLlave && Input.GetKeyDown(KeyCode.E))
        {
            // Recoger la llave
            llave.SetActive(false);
            puedeRecogerLlave = false;
            llaveEncontrada = true;
            textPorta.SetActive(false);
            activarpuerta();
        }

        if (puedeInteractuarMisterio && Input.GetKeyDown(KeyCode.E) && !llaveEncontrada)
        {
            textPorta.SetActive(false);
            textNada.SetActive(true);
            Invoke("noHayNada", 1f);
        }

        if (puedeInteractuarPista && Input.GetKeyDown(KeyCode.E) && !llaveEncontrada)
        {
            textPista.SetActive(true);
            Invoke("OcultarTextPista", 2f);
        }

        if (puedeInteractuarArmario && Input.GetKeyDown(KeyCode.E) && !llaveEncontrada)
        {
            interactuoConArmario = true;
            textPorta.SetActive(false);
            textNada.SetActive(true);
            Invoke("noHayNada", 1f);
        }

        if (puedeInteractuarVerde && Input.GetKeyDown(KeyCode.E) && !llaveEncontrada)
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

        if (puedeInteractuarCorrecto && Input.GetKeyDown(KeyCode.E) && !llaveEncontrada)
        {
            textPorta.SetActive(false);
            textCorrecto.SetActive(true);
            llave.SetActive(true);
            Invoke("OcultarTextCorrecto", 3f);
        }

        if (puedeRecogerLlave && Input.GetKeyDown(KeyCode.E))
        {
            llave.SetActive(false);
            textPorta.SetActive(false);
        }

    }
    public void activarpuerta()
    {
        if (puertacasa != null)
        {
            puertacasa.SetActive(true); 
        }
    }

    public void OnCollisionEnter2D(Collision2D objecteTocat)
    {
        // Cambiar escena inmediatamente si la llave fue encontrada y se toca la puerta
        if (objecteTocat.gameObject == puertacasa)
        {
            if (llaveEncontrada)
            {
                SceneManager.LoadScene("fuera");
                return; // Salimos de la función para evitar más verificaciones
            }
            else
            {
                Debug.Log("Necesitas la llave para abrir esta puerta.");
            }
        }

        // TAG MISTERIO
        if (objecteTocat.gameObject.tag == "misterio")
        {
            textPorta.SetActive(true);
            puedeInteractuarMisterio = true;
        }

        // TAG PISTA
        if (objecteTocat.gameObject.tag == "pista")
        {
            textPorta.SetActive(true);
            puedeInteractuarPista = true;
        }

        // TAG VERDE
        if (objecteTocat.gameObject.tag == "verde")
        {
            textPorta.SetActive(true);
            puedeInteractuarVerde = true;
        }

        // TAG CORRECTO
        if (objecteTocat.gameObject.tag == "correcto")
        {
            textPorta.SetActive(true);
            puedeInteractuarCorrecto = true;
        }

        // OBJETO ARMARIO
        if (objecteTocat.gameObject == armario)
        {
            textPorta.SetActive(true);
            puedeInteractuarArmario = true;
        }

        // OBJETO LLAVE
        if (objecteTocat.gameObject.tag == "llave")
        {
            Debug.Log("En contacto con la llave");
            textPorta.SetActive(true);
            puedeRecogerLlave = true;
        }

        // SALA
        if (objecteTocat.gameObject.tag == "sala")
        {
            SceneManager.LoadScene("sala2");
        }
    }

    public void OnCollisionExit2D(Collision2D objecteTocat)
    {
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

        if (objecteTocat.gameObject.tag == "llave")
        {
            textPorta.SetActive(false);
            puedeRecogerLlave = false;
        }
    }

    public void interactuar()
    {
        textPorta.SetActive(false);
    }

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
    public void quitexin()
    {
        TextoInicio.SetActive(false);
    }
}
