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
    public bool tocacof = true;
    public bool tocallav = true;
    public GameObject cofreAbierto;
    public GameObject llaveCasa;
    public GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        if (cofreAbierto != null) cofreAbierto.SetActive(false);
        if (llaveCasa != null) llaveCasa.SetActive(false);
        if (portal != null) portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (tocacof == true && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(cofreCerrado);
            Invoke ("activarCofre", 0f);
            tocacof = false;
            tocallav = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && tocallav == true)
        {
            Destroy(llaveCasa);
            textPortaPortal.SetActive(true);
            Invoke("interactuar3", 3.5f);
            Invoke("activarPortal", 0f);
            tocallav = false;
        }
    }
    //COLISION TEXTO PUERTA
    public void OnCollisionEnter2D(Collision2D objecteTocat)
    {
        if (objecteTocat.gameObject.tag == "cofre")
        {
            textPorta.SetActive(true);
            Invoke("interactuar", 0.5f);
            tocacof = true;
        }
        if (objecteTocat.gameObject.tag == "cofreAbierto")
        {
            textPortaLlave.SetActive(true);
            Invoke("interactuar2", 2.5f);
        }
        if (objecteTocat.gameObject.tag == "llave")
        {
            textPorta.SetActive(true);
            Invoke("interactuar", 0.5f);
            tocallav = true;
        }
    }

    //MOSTRAR TEXTO
    public void interactuar()
    {
       textPorta.SetActive(false);
    }

    //MOSTRAR TEXTO DE BUSCAR LLAVE
    public void interactuar2()
    {
        textPortaLlave.SetActive(false);
    }

    //MOSTRAR TEXTO DE BUSCAR PORTAL
    public void interactuar3()
    {
        textPortaPortal.SetActive(false);
    }

    //ACTIVAR COFRE Y LLAVE
    public void activarCofre()
    {
        if (cofreAbierto != null) cofreAbierto.SetActive(true);
        if (llaveCasa != null) llaveCasa.SetActive(true);
    }

    //ACTIVAR PORTAL
    public void activarPortal()
    {
        if(portal != null) portal.SetActive(true);
    }
}
