using UnityEngine;
using TMPro; // Necesario para trabajar con TextMeshPro
using UnityEngine.SceneManagement;

public class ContadorCoche : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI contadorText; // Referencia al contador en el Canvas
    private int contadorCoches = 0; // Contador inicial
    private const int maxCoches = 120; // Máximo de coches para ganar

    void Start()
    {
        ActualizarContador(); // Inicializa el contador al iniciar
    }

    public void IncrementarContador()
    {
        contadorCoches++;

        if (contadorCoches >= maxCoches)
        {
            contadorCoches = maxCoches; // Evita que pase del máximo
            CambiarEscena(); // Llama a CambiarEscena al alcanzar el máximo
        }

        ActualizarContador(); // Actualiza el texto del contador
    }

    public void RestarContador(int cantidad)
    {
        contadorCoches = Mathf.Max(0, contadorCoches - cantidad); // Evita valores negativos
        ActualizarContador(); // Actualiza el texto del contador
    }

    private void ActualizarContador()
    {
        if (contadorText != null)
        {
            contadorText.text = $"{contadorCoches}/{maxCoches}"; // Actualiza el texto
        }
        else
        {
            Debug.LogError("El objeto contadorText no está asignado en el Inspector.");
        }
    }

    private void CambiarEscena()
    {
        Debug.Log("¡Meta alcanzada! Cambiando a la escena 'Fin'.");
        SceneManager.LoadScene("Fin"); // Cambia a la escena llamada "Fin"
    }
}
