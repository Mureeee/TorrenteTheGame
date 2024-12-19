using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para cambiar de escena

public class Coches : MonoBehaviour
{
    private float vel;

    private Vector2 minPantalla;

    [SerializeField] private Sprite[] arraySpritesCoches = new Sprite[10];

    private int valorCoche;

    [SerializeField] private GameObject prefabExplosio;

    private static int contadorCoches = 0; // Contador de coches global
    private static int incrementoVelocidad = 20; // Cada cuántos coches aumentar la velocidad
    private static int vidas = 3; // Vidas del jugador

    // Start is called before the first frame update
    void Start()
    {
        vel = 15f;

        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        System.Random numAleatori = new System.Random();
        valorCoche = numAleatori.Next(0, 10);
        GetComponent<SpriteRenderer>().sprite = arraySpritesCoches[valorCoche];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posActual = transform.position;
        posActual = posActual + new Vector2(0, -1) * vel * Time.deltaTime;
        transform.position = posActual;

        if (transform.position.y < minPantalla.y)
        {
            // Incrementar contador de coches cuando se destruye
            contadorCoches++;
            Debug.Log("Coches pasados: " + contadorCoches);

            // Incrementar la velocidad cada 20 coches
            if (contadorCoches % incrementoVelocidad == 0)
            {
                vel += 2.5f; // Incremento de 2.5
                Debug.Log("Velocidad aumentada a: " + vel);
            }

            // Comprobar si se alcanzó el límite de 120 coches
            if (contadorCoches >= 120)
            {
                SceneManager.LoadScene("Final del Juego");
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Coche")
        {
            Debug.Log("cochetocao");
            GameObject explosio = Instantiate(prefabExplosio);
            explosio.transform.position = transform.position;

            // Reducir el contador de coches y vidas
            contadorCoches = Mathf.Max(0, contadorCoches - 5); // Reducir coches, mínimo 0
            vidas--;

            Debug.Log($"Vidas restantes: {vidas}. Coches restantes: {contadorCoches}");

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
        contadorCoches = 0; // Reiniciar coches pasados
        vidas = 3; // Restaurar vidas

        // Cargar la escena inicial o de reinicio
        SceneManager.LoadScene("Muerte 1");
        //dawdaw
    }
}
