using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonPartida : MonoBehaviour
{
    public void nuevaPartida()
    {
        SceneManager.LoadScene("Partida");
    }
}
