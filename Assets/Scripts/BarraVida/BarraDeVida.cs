using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{

    public Image barraDeVida;
    public float vidaActual;
    public float vidaM�xima = 20;
    public bool isChangingLive;

    private void Start()
    {
        vidaActual = vidaM�xima;
    }
    void Update()
    {
        if(vidaActual >= vidaM�xima)
        {
            vidaActual = 20;
        }
        if (isChangingLive == false)
        {
            isChangingLive = true;
            StartCoroutine(PerderVida());
        }
        barraDeVida.fillAmount = vidaActual / vidaM�xima;
    }
    public IEnumerator PerderVida()
    {
        yield return new WaitForSeconds(1);
        vidaActual--;
        isChangingLive = false;
    }
}
