using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNumeros : MonoBehaviour
{
    [SerializeField] private GameObject prefabNum;
    private Vector2 minpantalla, maxpantalla;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerarNumero", 1f, 2f);
        minpantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxpantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void GenerarNumero()
    {
        GameObject numero = Instantiate(prefabNum);

        numero.transform.position = new Vector2(Random.Range(minpantalla.x, maxpantalla.x), maxpantalla.y);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
