using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCoche : MonoBehaviour
{
    public float velocidadAdelante = 15f; // Velocidad del movimiento hacia adelante y atrás
    public float velocidadLateral = 15f; // Velocidad del movimiento lateral

    public GameObject panelGameOver; // Panel que aparece al perder
    private bool esInvencible = false; // Si el jugador es invencible temporalmente
    public GameObject Coche;

    void Start()
    {
        // Asegurarse de que el juego comienza sin el panel de "Game Over"
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(false);
        }
    }

    void Update()
    {
        // Movimiento con las teclas WASD
        Movimiento();
    }

    void Movimiento()
    {
        // Movimiento hacia adelante y atrás (W/S)
        float movimientoVertical = Input.GetAxis("Vertical") * velocidadAdelante * Time.deltaTime;
        transform.Translate(Vector3.up * movimientoVertical);

        // Movimiento lateral (A/D)
        float movimientoLateral = Input.GetAxis("Horizontal") * velocidadLateral * Time.deltaTime;
        transform.Translate(Vector3.right * movimientoLateral);
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        // Si el coche choca con un objeto con la etiqueta "Cars" y no es invencible, termina el juego
        if (colision.gameObject.CompareTag("Cars") && !esInvencible)
        {
            if (panelGameOver != null)
            {
                panelGameOver.SetActive(true);
            }
            Time.timeScale = 0; // Pausa el juego
        }
        // Si recoge una moneda
        else if (colision.gameObject.CompareTag("Coin"))
        {
            // Destruye la moneda y activa invencibilidad temporal
            Destroy(colision.gameObject);
            StartCoroutine(ActivarInvencibilidad());
        }
    }

    private IEnumerator ActivarInvencibilidad()
    {
        esInvencible = true; // Activar invencibilidad
        yield return new WaitForSeconds(2f); // Esperar 2 segundos
        esInvencible = false; // Desactivar invencibilidad
    }
}
