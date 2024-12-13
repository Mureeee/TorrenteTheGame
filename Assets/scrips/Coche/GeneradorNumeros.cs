using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Repas
 *
 * Que hem vist:
 *      - crear objectes a l'ascena.
 *      - crear EmptyObject(per exemple per fer el GeneradorNumeros).
 *      - Prefabs (per crear objectes quan el joc esta en execusio).
 *          - per crear-los: l'objecta que ja teniem creat l'arroseguem a la carpeta prefabs.
 *          - per crear un prefab a l'escena en execucio: metode Instantiate(variablePrefab).
 *              - variablePrefab: variable de tipus GameObject.
 *      - trobar posició objecta actual: transform.position
 *      - trobar marges pantalla: Camera.main.ViewportToWorldPoint().
 *      - [SerilizeFiled]: per fer que una variable private de la classe es mostri a l'editor de Unity.
 *      - Utilitzar una imatge/sprite com si fos mes d'una (contenint subimatges)
 *          - seleccionem l'esprite.
 *          - en l'opcio Sprite Mode canviem de single a multiple, i cliquem boto Apply
 *          - fem servir les opcions del boto sprite editor
 *      - Destruir objecte actual: Destroy(gameObject).
 *      - cridar un metode al cap de x segons: Invoke("NomMetode", xf).
 *      - cridar un metode al cap de x segons i cada y segons: InvokeRepeting("NomMetode", xf, yf).
 *      - com aturar un InvokeRepeating: CancelInvoke("NomMetode").
 *      - detectar objecte toca a un altre:
 *          - afagir als objectes que volem que es toquin, els components: BoxXollider2D i Rigibody2D.
 *          - en Boxcollider2D: activar checkbox IsTrigger.
 *          - en RigidBody2D: gravitiScale posar-ho a 0
 */


public class MovimientoCoche : MonoBehaviour
{
    private float _vel;
    Vector2 minPantalla, maxPantalla;

    [SerializeField] private GameObject prefabExplosion;
    [SerializeField] private GameObject cochePrefab;

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
        Debug.Log("X: " + direccioIndicadaX + "Y: " + direccioIndicadaY);
        Vector2 direccioIndicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;

        Vector2 novaPos = transform.position;//transform.position: pos actual de la nau
        novaPos = novaPos + direccioIndicada * _vel * Time.deltaTime;

        novaPos.x = Mathf.Clamp(novaPos.x, minPantalla.x, maxPantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minPantalla.y, maxPantalla.y);

        transform.position = novaPos;
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.gameObject == cochePrefab)
        {
            vidas--;
            Debug.Log("hola");

            if (vidas < 0)
            {
                GameObject explosion = Instantiate(prefabExplosion);
                explosion.transform.position = transform.position;

                SceneManager.LoadScene("Muerte1");

                Destroy(gameObject);
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

    public void reducirVida()
    {
        if (vidas > 0)
        {
            vidas--;
            ActualizarCorazones();
        }

        if (vidas <= 0)
        {
            SceneManager.LoadScene("Muerte1");
        }
    }
}