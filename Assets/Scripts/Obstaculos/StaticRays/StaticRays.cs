using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticRays : MonoBehaviour
{
    [SerializeField] private GameObject[] AlertaLasers;
    public bool isGeneratingAlertaLaser;

    void Start()
    {
        isGeneratingAlertaLaser = false;
    }
    private void Update()
    {
        if (isGeneratingAlertaLaser == false)
        {
            isGeneratingAlertaLaser = true;
            StartCoroutine(GenerateAlertasLaser());
        }
    }
    IEnumerator GenerateAlertasLaser()
    {
        yield return new WaitForSeconds(1);
        AlertaLasers[Random.Range(0, AlertaLasers.Length)].SetActive(true);
        yield return new WaitForSeconds(11);
        isGeneratingAlertaLaser = false;
    }
    public void OnDisable()
    {
        isGeneratingAlertaLaser = false;
    }
}
