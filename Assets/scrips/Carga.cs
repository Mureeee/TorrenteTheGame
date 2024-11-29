using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carga : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Historia";
    [SerializeField] private float loadingTime = 4f; // Duración de la pantalla de carga.

    private void Start()
    {
        // Inicia la pantalla de carga con los valores predeterminados.
        StartLoading();
    }

    // Función para iniciar la pantalla de carga con valores opcionales.
    public void StartLoading(string sceneName = null, float time = -1f)
    {
        if (sceneName != null)
            nextSceneName = sceneName; // Cambia la escena si se proporciona un valor.

        if (time >= 0)
            loadingTime = time; // Cambia el tiempo de espera si se proporciona un valor.

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
