    using JetBrains.Annotations;
    using System.Collections;
    using System.Collections.Generic;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;
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
        public GameObject salida;
        private bool estaEnP1 = false;
        private bool estaEnP2 = false;
        private bool estaEnP3 = false;
        private bool estaEnP4 = false;
        public GameObject paredMid;
        public GameObject puertaCof;
        public GameObject pared;
        public GameObject textPortaCasa;
        public int vidasT;
        public GameObject[] corazones;
        public GameObject TextoInicio;


        //--------------------------------------------
        public GameObject panelOperacion;
        public TextMeshPro operacionText;
        public GameObject P1;
        public GameObject P2;
        public GameObject P3;
        public GameObject P4;
        private int numero1, numero2, resultadoCorrecto;
        private bool panelActivo = false; // Bandera para saber si el panel está activo

        [SerializeField] private Button BotonValidar; // Botón de confirmación
        [SerializeField] private TMP_InputField Respuesta;
        [SerializeField] private TMPro.TextMeshProUGUI componentTextVides;

        // Start is called before the first frame update
        void Start()
        {
        TextoInicio.SetActive(true);
        Invoke("quitexin", 5f);
        _vel = 8f;
            rigidbody = GetComponent<Rigidbody2D>();
            panelOperacion.SetActive(false);

            if (VariablesGlobales.escenaAnterior == "cofre")
            {
                transform.position = VariablesGlobales.posTorrenteGuardada;
            }
            if (VariablesGlobales.escenaAnterior == "casa")
            {
                transform.position = VariablesGlobales.posTorrenteGuardada;
            }
            vidasT = 3;
            ActualizarCorazones();
        }

        // Update is called once per frame
        void Update()
        {
            moverTorrente();
            colisionTorrente();

            if ((estaEnP1 || estaEnP2 || estaEnP3 || estaEnP4) && Input.GetKeyDown(KeyCode.E) && !panelActivo)
            {
                GenerarOperacion();
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
                panelActivo = false;

                if (estaEnP1) { P1.SetActive(false); estaEnP1 = false; }
                if (estaEnP2) { P2.SetActive(false); paredMid.SetActive(false); estaEnP2 = false; }
                if (estaEnP3) { P3.SetActive(false); puertaCof.SetActive(false); estaEnP3 = false; }
                if (estaEnP4) { P4.SetActive(false); estaEnP4 = false; }
            }
            else
            {
                Debug.Log("Respuesta incorrecta. Intenta de nuevo.");
                reducirVida();
            }
        }
        else
        {
            Debug.Log("Por favor, introduce un número válido.");
        }
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

            rigidbody.velocity = new Vector2(inputHorizontal, inputVertical);
        }

        //COLISION TEXTO PUERTA
        public void OnCollisionEnter2D(Collision2D objecteTocat)
        {
            if (objecteTocat.gameObject.tag == "Porta")
            {
                porta1.SetActive(true);
                Invoke("DesactivarPorta1", 2f);
                estaEnP1 = true;
            }
            if (objecteTocat.gameObject.tag == "Porta2")
            {
                porta1.SetActive(true);
                Invoke("DesactivarPorta1", 2f);
                estaEnP2 = true;
            }
            if (objecteTocat.gameObject.tag == "Porta3")
            {
                porta1.SetActive(true);
                Invoke("DesactivarPorta1", 2f);
                estaEnP3 = true;
            }
            if (objecteTocat.gameObject.tag == "Porta4")
            {
                porta1.SetActive(true);
                Invoke("DesactivarPorta1", 2f);
                estaEnP4 = true;
            }
            if (objecteTocat.gameObject.tag == "salida")
            {
                textPortaCasa.SetActive(true);
                Invoke("interactuar2", 2f);
            }
            if (objecteTocat.gameObject.tag == "sala")
            {
                VariablesGlobales.posTorrenteGuardada = transform.position;
                if (VariablesGlobales.escenaAnterior != "cofre")
                {
                    SceneManager.LoadScene("cofre");
                }
            if (VariablesGlobales.escenaAnterior == "cofre")
            {
                paredMid.SetActive(false);
                pared.SetActive(false); 
            }
            }
            if(objecteTocat.gameObject.tag == "salida")
            {
                VariablesGlobales.posTorrenteGuardada = transform.position;
                if (objecteTocat.gameObject.tag == "salida")
                {
                    Destroy(objecteTocat.gameObject);
                    SceneManager.LoadScene("casa");
                }
            }
        
        }

        private void OnCollisionExit2D(Collision2D objecteTocat)
        {
            if (objecteTocat.gameObject.tag == "Porta")
            {
                estaEnP1 = false;
            }
            if (objecteTocat.gameObject.tag == "Porta2")
            {
                estaEnP2 = false;
            }
            if (objecteTocat.gameObject.tag == "Porta3")
            {
                estaEnP3 = false;
            }
            if (objecteTocat.gameObject.tag == "Porta4")
            {
                estaEnP4 = false;
            }
        
        }

        //DESACTIVAR PUERTA
        public void DesactivarPorta1()
        {
            porta1.SetActive(false);
        }
        public void SalirDelJuego()
        {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        }

    public void quitexin()
    {
        TextoInicio.SetActive(false);
    }
        
        public void interactuar2()
        {
            textPortaCasa.SetActive(false);
        }

        private void ActualizarCorazones()
        {
            for (int i = 0; i < corazones.Length; i++)
            {
                corazones[i].SetActive(i < vidasT);
            }
        }

        // REDUCE UNA VIDA Y ACTUALIZA LOS CORAZONES
        public void reducirVida()
        {
            if (vidasT > 0)
            {
                vidasT--;
                ActualizarCorazones();
            }

            if (vidasT <= 0)
            {
                SceneManager.LoadScene("Muerte");
            }
        }
}
