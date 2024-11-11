using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.ShaderData;
using TMPro;

public class MovimientoT : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private float _vel;
    Vector2 minPantalla, maxPantalla;
    private Vector3 velocity;
    public float direccioIndicadaX;
    public float direccioIndicadaY;
    public GameObject porta1;
    public bool textOperacion = false;

    //--------------------------------------------
    public GameObject panelOperacion;
    public TextMeshPro operacionText;
    //public InputField respuestaInput;
    public GameObject P1;
    private int numero1, numero2, resultadoCorrecto;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8f;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float meitatMidaImatgeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float meitatMidaImatgeY = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y / 2;

        minPantalla.x = minPantalla.x + meitatMidaImatgeX;
        maxPantalla.x = maxPantalla.x - meitatMidaImatgeX;

        rigidbody = GetComponent<Rigidbody2D>();

        panelOperacion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        moverTorrente();
        colisionTorrente();

        if (Input.GetKeyDown(KeyCode.E))
        {
            GenerarOperacion();
        }

    }

    public void GenerarOperacion()
    {
        // Generar dos n�meros aleatorios
        numero1 = Random.Range(1, 10);
        numero2 = Random.Range(1, 10);
        resultadoCorrecto = numero1 + numero2; // Puedes cambiar esto para otros operadores

        // Mostrar la operaci�n
        operacionText.text = $"{numero1} + {numero2} = ?";
        panelOperacion.SetActive(true); // Muestra el panel
    }

    /*public void VerificarRespuesta()
    {
        int respuestaUsuario;
        if (int.TryParse(respuestaInput.text, out respuestaUsuario) && respuestaUsuario == resultadoCorrecto)
        {
            // Si la respuesta es correcta, desactiva la colisi�n
            //P1.enabled = false;
            panelOperacion.SetActive(false); // Oculta el panel
            Debug.Log("�Respuesta correcta!");
        }
        else
        {
            Debug.Log("Respuesta incorrecta. Intenta de nuevo.");
        }
    }*/

        public void moverTorrente()
    {
        direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        direccioIndicadaY = Input.GetAxisRaw("Vertical");
        Vector2 direccioIndicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;
    }

    public void colisionTorrente()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal") * _vel;
        float inputVertical = Input.GetAxisRaw("Vertical") * _vel;

        rigidbody.velocity = new Vector2(inputHorizontal, inputVertical);
    }


    public void OnCollisionEnter2D(Collision2D objecteTocat)
    {
        if (objecteTocat.gameObject.tag == "Porta")
        {
            //GameObject.Find("TextPorta").SetActive(true);
            porta1.SetActive(true);
            Invoke("DesactivarPorta1", 2f);
            if (!textOperacion)
            {
                
            }
        }
        

    }
    public void DesactivarPorta1()
    {
        porta1.SetActive(false);
    }

}
