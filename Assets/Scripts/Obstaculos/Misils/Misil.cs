using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : MonoBehaviour
{
    public GameObject target;
    public float misilSpeed = 3f;
    public GameObject camera_Transform;
    public float tiempobuscando = 4 ;
    public bool buscando = true;
    public GameObject misil;

    private void Start()
    {
        camera_Transform = Camera.main.gameObject;
        target = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(camera_Transform.transform.position.x + 15, target.transform.position.y, target.transform.position.z);
        StartCoroutine(LanzarMisil());
    }
    void Update()
    {
        if (buscando == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(camera_Transform.transform.position.x + 15, target.transform.position.y, target.transform.position.z), misilSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(camera_Transform.transform.position.x + 15, transform.position.y, target.transform.position.z), misilSpeed * Time.deltaTime);
        }
    }
    public IEnumerator LanzarMisil()
    {
        yield return new WaitForSeconds(tiempobuscando);
        buscando = false;
        yield return new WaitForSeconds(2);
        Instantiate(misil, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), transform.rotation);
        Destroy(gameObject);
    }
}
