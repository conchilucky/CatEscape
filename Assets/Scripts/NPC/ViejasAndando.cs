using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViejasAndando : MonoBehaviour
{
    public float viejaSpeedMove = 0.2f;
    public Rigidbody rbVieja;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    void Update()
    {
       rbVieja.AddForce(-viejaSpeedMove, 0, 0, ForceMode.Impulse);
    }
}
