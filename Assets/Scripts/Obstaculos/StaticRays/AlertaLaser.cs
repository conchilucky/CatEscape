using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertaLaser : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(DesactivarLaser());
    }
    public IEnumerator DesactivarLaser()
    {     
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
