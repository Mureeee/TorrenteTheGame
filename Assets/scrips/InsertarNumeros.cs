using TMPro;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InsertarNumeros : MonoBehaviour
{
    public TMP_InputField inputField;  // Cambiado a TMP_InputField para mayor compatibilidad con TextMeshPro
    public MovimientoT movimientoScript;  // Referencia al script MovimientoT

    void Update()
    {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                if (keyCode >= KeyCode.Alpha0 && keyCode <= KeyCode.Alpha9)
                {
                    char numeroIngresado = (char)((int)keyCode - (int)KeyCode.Alpha0 + '0');
                    inputField.text += numeroIngresado;
                }
                else if (keyCode == KeyCode.Return)  // Detecta si el usuario presionó Enter
                {
                }
            }
        }
    }
}
