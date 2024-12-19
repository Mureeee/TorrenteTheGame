using UnityEngine;
using UnityEngine.SceneManagement;

public class Coches : MonoBehaviour
{
    private float vel;

    private Vector2 minPantalla;

    [SerializeField] private Sprite[] arraySpritesCoches = new Sprite[10];

    private int valorCoche;

    [SerializeField] private GameObject prefabExplosio;

    private static int vidas = 3; // Vidas del jugador

    void Start()
    {
        vel = 15f;

        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        System.Random numAleatori = new System.Random();
        valorCoche = numAleatori.Next(0, 10);
        GetComponent<SpriteRenderer>().sprite = arraySpritesCoches[valorCoche];
    }

    void Update()
    {
        Vector2 posActual = transform.position;
        posActual = posActual + new Vector2(0, -1) * vel * Time.deltaTime;
        transform.position = posActual;

        if (transform.position.y < minPantalla.y)
        {
            // Incrementar el contador de coches pasados
            FindObjectOfType<ContadorCoche>().IncrementarContador();

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Coche")
        {
            Debug.Log("Coche tocado");
            GameObject explosio = Instantiate(prefabExplosio);
            explosio.transform.position = transform.position;

            // Reducir el contador de coches y vidas
            FindObjectOfType<ContadorCoche>().RestarContador(5); // Resta 5 coches
            vidas--;

            if (vidas <= 0)
            {
                ReiniciarJuego();
            }

            Destroy(gameObject);
        }
    }

    private void ReiniciarJuego()
    {
        Debug.Log("Reiniciando el juego...");
        vidas = 3; // Restaurar vidas
        SceneManager.LoadScene("Muerte 1");
    }
}
