using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoCoche : MonoBehaviour
{
    private float _vel = 5f; // Asignar un valor por defecto para la velocidad
    private Vector2 _minPantalla, _maxPantalla;

    [SerializeField] private GameObject prefabExplosion;
    [SerializeField] private GameObject cochePrefab;
    public GameObject[] corazones;
    public int vidasT;
    [SerializeField] private TMPro.TextMeshProUGUI componentTextVides;

    void Start()
    {
        _minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        _maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float mitadAnchoTarget = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float mitadAltoTarget = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y / 2;

        _minPantalla.x += mitadAnchoTarget;
        _maxPantalla.x -= mitadAnchoTarget;

        _minPantalla.y += mitadAltoTarget;
        _maxPantalla.y -= mitadAltoTarget;

        vidasT = 3; // Establecer las vidas iniciales
        ActualizarCorazones(); // Actualizar los corazones
    }

    void Update()
    {
        MoverNau();
    }

    private void MoverNau()
    {
        float direccionHorizontal = Input.GetAxisRaw("Horizontal");
        float direccionVertical = Input.GetAxisRaw("Vertical");

        Vector2 direccionClamped = new Vector2(direccionHorizontal, direccionVertical).normalized;
        Vector2 nuevoPos = (Vector2)transform.position + direccionClamped * _vel * Time.deltaTime;

        nuevoPos.x = Mathf.Clamp(nuevoPos.x, _minPantalla.x, _maxPantalla.x);
        nuevoPos.y = Mathf.Clamp(nuevoPos.y, _minPantalla.y, _maxPantalla.y);

        transform.position = nuevoPos;
    }

    private void OnTriggerEnter2D(Collider2D objetoTocado)
    {
        if (objetoTocado.CompareTag("Coche")) // Usar la etiqueta "Coche" para la comparación
        {
            Debug.Log("Choque!");
            vidasT--;

            if (vidasT > 0)
            {
                GameObject explosion = Instantiate(prefabExplosion);
                explosion.transform.position = transform.position;
            }
            else
            {
                // Cargar la pantalla de "Game Over" u otro manejo de fin de juego
                Debug.Log("Fin del juego");
                Destroy(gameObject);
            }

            ActualizarCorazones(); // Actualizar los corazones
        }
    }

    private void ActualizarCorazones()
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].SetActive(i < vidasT);
        }

        // Opcional: Actualizar el texto de vidas en pantalla si lo tienes configurado
        if (componentTextVides != null)
        {
            componentTextVides.text = "Vidas: " + vidasT;
        }
    }

    public void reducirVida()
    {
        if (vidasT > 0)
        {
            vidasT--;
            ActualizarCorazones();
        }

        if (vidasT <= 0)
        {
            SceneManager.LoadScene("Muerte"); // Cambiar a la escena de muerte
        }
    }
}
