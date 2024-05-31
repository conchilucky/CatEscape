using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMandarinas : MonoBehaviour
{  
    public  Text textoInventario;
    private void Start()
    {
        investario.CantidadMandarina = 0;
    }
    public void Update()
    {
        if (textoInventario != null)
        {
            textoInventario.text = ": " + investario.CantidadMandarina.ToString();
        }
    }
}
