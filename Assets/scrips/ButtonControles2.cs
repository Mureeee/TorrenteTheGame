using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControles2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void anaraControls2()
    {
        SceneManager.LoadScene("ControlesEnPartida");
    }
    public void anaraControls3()
    {
        SceneManager.LoadScene("ControlesEnCasa");
    }
    public void anaraControls4()
    {
        SceneManager.LoadScene("controles4");
    }
}
