using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carga : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Historia"; 
    [SerializeField] private float loadingTime = 4f; // Duración de la pantalla de carga.

    private void Start()
    {
        // Inicia la corrutina para cargar la escena después de 5 segundos.
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        // Espera el tiempo especificado.
        yield return new WaitForSeconds(loadingTime);

        // Carga la siguiente escena.
        SceneManager.LoadScene(nextSceneName);
    }
}

