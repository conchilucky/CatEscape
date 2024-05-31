using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject laser;
    public GameObject RealLaser;
    public bool isGeneratingWater;
    public AudioClip audioAgua;

    void Start()
    {
        isGeneratingWater = false;
    }
    private void Update()
    {     
        if (isGeneratingWater == false)
        {
            isGeneratingWater = true;
            StartCoroutine(DestruirLaser());
        }
    }
    public IEnumerator DestruirLaser()
    {
        yield return new WaitForSeconds(2);
        isGeneratingWater = false;
        laser.SetActive(false);
        RealLaser.SetActive(true);
        ControladorSonido.Instance.EjecutarSonido(audioAgua);
        RealLaser.transform.position = new Vector3(RealLaser.transform.position.x, transform.position.y, RealLaser.transform.position.z);
    }
}
