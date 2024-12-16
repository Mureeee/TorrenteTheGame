using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coches : MonoBehaviour
{
    private float vel;

    private Vector2 minPantalla;

    [SerializeField] private Sprite[] arraySpritesCoches = new Sprite[10];

    private int valorCoche;

    [SerializeField] private GameObject prefabExplosio;


    // Start is called before the first frame update
    void Start()
    {
        vel = 12f;

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

            //DadesGlobals.punts += valorNumero;

            Destroy(gameObject);
        }
    }
}

