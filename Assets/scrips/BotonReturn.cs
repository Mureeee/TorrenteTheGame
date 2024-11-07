using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonReturn : MonoBehaviour
{
    public void pantallaReturn()
    {
        Debug.Log("Hola");
        SceneManager.LoadScene("sala2");
    }
}
