using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoCoche : MonoBehaviour
{
    private float _vel;
    Vector2 minPantalla, maxPantalla;

    [SerializeField] private GameObject prefabExplosion;
    [SerializeField] private GameObject cochePrefab;
    [SerializeField] private Transform spawnZona; // Zona donde aparecerán los coches enemigos

    public GameObject[] corazones;

    private int vidas;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 6;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float meitatMidaImatgeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float meitatMidaImatgeY = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y / 2;

        minPantalla.x = minPantalla.x + meitatMidaImatgeX;
        maxPantalla.x = maxPantalla.x - meitatMidaImatgeX;

        vidas = 3;
        ActualizarCorazones();

        // Inicia la generación de coches enemigos
        InvokeRepeating("GenerarCocheEnemigo", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        MoureNau();
    }

    private void MoureNau()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaY = Input.GetAxisRaw("Vertical");
        Vector2 direccioIndicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;

        Vector2 novaPos = transform.position;
        novaPos = novaPos + direccioIndicada * _vel * Time.deltaTime;

        novaPos.x = Mathf.Clamp(novaPos.x, minPantalla.x, maxPantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minPantalla.y, maxPantalla.y);

        transform.position = novaPos;
    }

    private void GenerarCocheEnemigo()
    {
        float xPos = Random.Range(minPantalla.x, maxPantalla.x);
        Vector2 spawnPos = new Vector2(xPos, spawnZona.position.y);
        Instantiate(cochePrefab, spawnPos, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.gameObject.CompareTag("Enemigo")) // Asegúrate de asignar el tag "Enemigo" a los coches enemigos
        {
            vidas--;

            GameObject explosion = Instantiate(prefabExplosion);
            explosion.transform.position = objecteTocat.transform.position;

            Destroy(objecteTocat.gameObject);

            if (vidas <= 0)
            {
                GameObject jugadorExplosion = Instantiate(prefabExplosion);
                jugadorExplosion.transform.position = transform.position;

                Destroy(gameObject);
                SceneManager.LoadScene("Muerte1");
            }
            else
            {
                ActualizarCorazones();
            }
        }
    }

    private void ActualizarCorazones()
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].SetActive(i < vidas);
        }
    }
}
