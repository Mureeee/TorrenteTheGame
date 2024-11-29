using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoPausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    public bool Pausa = false;
    public GameObject torrente;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (!Pausa)
            { 
                ObjetoMenuPausa.SetActive(true);
                Pausa = true;
               // torrente.SetActive(false);

            }
            else
            {
                Resumir(); // Llamas a la función Resumir para cerrar el menú de pausa
            }
        }
    }
    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false);
        Pausa = false;
        
    }
}