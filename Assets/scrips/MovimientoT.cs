using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UI;
using TMPro.Examples;



public class MovimientoT : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private float _vel;
    Vector2 minPantalla, maxPantalla;
    private Vector3 velocity;
    public float direccioIndicadaX;
    public float direccioIndicadaY;
    public GameObject porta1;
    //public GameObject cofre;
    public GameObject salida;
    public bool textOperacion = false;
    private bool estaEnP1 = false;

    //--------------------------------------------
    public GameObject panelOperacion;
    public TextMeshPro operacionText;
    //public InputField respuestaInput;
    public GameObject P1;
    private int numero1, numero2, resultadoCorrecto;
    //public TextMeshPro Respuesta;

    private bool panelActivo = false; // Bandera para saber si el panel está activo

    [SerializeField] private Button BotonValidar; // Botón de confirmación
    [SerializeField] private TMP_InputField Respuesta;



    // Start is called before the first frame update
    void Start()
    {

        _vel = 8f;
        //minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        //maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //float meitatMidaImatgeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        //float meitatMidaImatgeY = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y / 2;

        //minPantalla.x = minPantalla.x + meitatMidaImatgeX;
        //maxPantalla.x = maxPantalla.x - meitatMidaImatgeX;

        rigidbody = GetComponent<Rigidbody2D>();

        panelOperacion.SetActive(false);

        if (VariablesGlobales.escenaAnterior == "cofre")
        {
            transform.position = VariablesGlobales.posTorrenteGuardada;
        }

        //BotonValidar.onClick.AddListener(VerificarRespuesta);

    }

    // Update is called once per frame
    void Update()
    {

        moverTorrente();
        colisionTorrente();

        // Solo genera operación si está en P1, se presiona "E", y el panel no está activo
        if (estaEnP1 && Input.GetKeyDown(KeyCode.E) && !panelActivo)
        {
            Debug.Log("Generando operación...");
            GenerarOperacion();
        }

        // Cierra el panel si el jugador sale de P1 y el panel está activo
        if (!estaEnP1 && panelActivo)
        {
            CerrarPanelOperacion();
        }
    }

    //GENERAR OPERACION
    public void GenerarOperacion()
    {
        int num1 = Random.Range(1, 10);
        int num2 = Random.Range(1, 10);
        int operador = Random.Range(0, 4); // 0: suma, 1: resta, 2: multiplicación, 3: división
        string operacionTexto = "";

        switch (operador)
        {
            case 0: // Suma
                resultadoCorrecto = num1 + num2;
                operacionTexto = num1 + " + " + num2;
                break;

            case 1: // Resta
                resultadoCorrecto = num1 - num2;
                operacionTexto = num1 + " - " + num2;
                break;

            case 2: // Multiplicación
                resultadoCorrecto = num1 * num2;
                operacionTexto = num1 + " * " + num2;
                break;

            case 3: // División (asegura que el resultado sea entero)
                num1 = num1 * num2; // Así el primer número será divisible por el segundo
                resultadoCorrecto = num1 / num2;
                operacionTexto = num1 + " / " + num2;
                break;
        }

        // Muestra la operación en el texto y limpia el campo de respuesta
        operacionText.text = operacionTexto + " = ";
        Respuesta.text = ""; // Limpia el campo de entrada
        panelOperacion.SetActive(true);
        panelActivo = true; // Marca el panel como activo
    }

    // Verifica la respuesta del jugador
    public void VerificarRespuesta()
    {
        int respuestaJugador;
        if (int.TryParse(Respuesta.text, out respuestaJugador))
        {
            if (respuestaJugador == resultadoCorrecto)
            {
                Debug.Log("¡Respuesta correcta!");
                panelOperacion.SetActive(false); 
            }
            else
            {
                Debug.Log("Respuesta incorrecta. Intenta de nuevo.");
                GenerarOperacion(); 
            }
        }
        else
        {
            Debug.Log("Por favor, introduce un número válido.");
        }
    }

    // Cierra el panel de operación
    public void CerrarPanelOperacion()
    {
        panelOperacion.SetActive(false);
        panelActivo = false; // Marca el panel como inactivo
    }

    //MOVIMIENTO TORRENTE
    public void moverTorrente()
    {
        direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        direccioIndicadaY = Input.GetAxisRaw("Vertical");
        Vector2 direccioIndicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;
    }

    //COLISIONES TORRENTE
    public void colisionTorrente()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal") * _vel;
        float inputVertical = Input.GetAxisRaw("Vertical") * _vel;

        Debug.Log("hola");

        rigidbody.velocity = new Vector2(inputHorizontal, inputVertical);
    }

    //COLISION TEXTO PUERTA
    public void OnCollisionEnter2D(Collision2D objecteTocat)
    {
        if (objecteTocat.gameObject.tag == "Porta")
        {
            porta1.SetActive(true);
            Invoke("DesactivarPorta1", 2f);

            estaEnP1 = true; // El jugador está tocando P1
        }
        if (objecteTocat.gameObject.tag == "sala")
        {
            VariablesGlobales.posTorrenteGuardada = transform.position;
            if (VariablesGlobales.escenaAnterior != "cofre")
            {
                SceneManager.LoadScene("cofre");
            }
        }
        if (objecteTocat.gameObject.tag == "salida")
        {
            SceneManager.LoadScene("casa");
        }
    }

    private void OnCollisionExit2D(Collision2D objecteTocat)
    {
        if (objecteTocat.gameObject.tag == "Porta")
        {
            Debug.Log("Saliendo de P1...");

            estaEnP1 = false; // El jugador ha salido de P1
        }
    }

    //DESACTIVAR PUERTA
    public void DesactivarPorta1()
    {
        porta1.SetActive(false);
    }
}
