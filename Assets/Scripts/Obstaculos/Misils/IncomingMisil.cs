using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomingMisil : MonoBehaviour
{
    public float velocidad = 10;
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * velocidad * Time.deltaTime);   
    }
}
