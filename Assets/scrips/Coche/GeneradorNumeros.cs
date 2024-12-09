using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNumeros1 : MonoBehaviour
{
    [SerializeField] private GameObject prefabNum;
    private Vector2 minPantalla, maxPantalla;

    public GameObject cochePrefab; // Prefab del coche
    public float limiteIzquierdo = -5f; // Ajusta según tu escena
    public float limiteDerecho = 5f;    // Ajusta según tu escena
    public float posicionYInicial = 5f;  // Ajusta para la posición en Y
    public float intervaloGeneracion = 2f; // Tiempo entre generaciones

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerarNumero", 1f, 1.5f);

        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2 (1, 1));
        // Comenzar a generar coches periódicamente
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerarNumero()
    {

        float posicionX = Random.Range(limiteIzquierdo, limiteDerecho);
        Vector3 posicion = new Vector3(posicionX, posicionYInicial, 0);

        // Instanciar el coche en la posición generada
        Instantiate(cochePrefab, posicion, Quaternion.identity);

    }
}
