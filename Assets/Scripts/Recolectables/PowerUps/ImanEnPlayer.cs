using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImanEnPlayer : MonoBehaviour
{
    public float fuerzaDeAtracción = 15f;
    public float rangoDeAtracción = 8f;
    private void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, rangoDeAtracción);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("RatonNormal"))
            {
                Vector3 direccionFuerza = transform.position - hitCollider.transform.position;
                hitCollider.GetComponent<Rigidbody>().AddForce(direccionFuerza.normalized * fuerzaDeAtracción);
            }
        }
    }

}
