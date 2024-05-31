using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestPlayerLife : MonoBehaviour
{
    public DamageData damageData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<CharacterController3D>().Restardlife(damageData.damage);
        }
    }
}
