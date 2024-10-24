using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoT : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private float _vel;
    Vector2 minPantalla, maxPantalla;
    private Vector3 velocity;
    public float direccioIndicadaX;
    public float direccioIndicadaY;


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
    }

    // Update is called once per frame
    void Update()
    {
        moverTorrente();
        colisionTorrente();
    }


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
            GameObject.Find("TextPorta").SetActive(true);
        }
    }


}
