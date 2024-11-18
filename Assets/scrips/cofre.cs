using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cofre : MonoBehaviour
{
    public GameObject cofreCerrado;
    public GameObject textPorta;
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
        if (Input.GetKeyDown(KeyCode.E) && tocacof == true)
        {
            Destroy(cofreCerrado);
            Invoke ("activarCofre", 0f);
            tocacof = false;
            tocallav = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && tocallav == true)
        {
            Destroy(llaveCasa);
            Invoke("activarPortal", 0f);
            tocallav = false;
        }
        if (tocallav == true)
        {
            Invoke("DesactivarPorta2", 1f);
        }
    }
    //COLISION TEXTO PUERTA
    public void OnCollisionEnter2D(Collision2D objecteTocat)
    {
        if (objecteTocat.gameObject.tag == "cofre")
        {
            textPorta.SetActive(true);
            Invoke("interactuar", 1f);
            tocacof = true;
        }
        if (objecteTocat.gameObject.tag == "llave")
        {
            textPorta.SetActive(true);
            Invoke("interactuar", 2f);
            tocallav = true;
        }
    }

    //DESACTIVAR PUERTA
    public void interactuar()
    {
       textPorta.SetActive(false);
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
