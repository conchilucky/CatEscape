using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class interaccionObjetos : MonoBehaviour
{
    public BarraDeVida barraVida;
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "ModoPerderVide")
        {
            barraVida = GameObject.Find("CanvasSliderVida").GetComponent<BarraDeVida>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            investario.OnCoinCollected.Invoke();
            if (barraVida != null)
            {
                barraVida.vidaActual++;
            }
            Destroy(gameObject);
        }
    }
}
