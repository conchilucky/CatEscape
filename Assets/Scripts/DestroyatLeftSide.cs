using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyatLeftSide : MonoBehaviour
{
    public GameObject camera_Transform;
    void Start()
    {
        camera_Transform = Camera.main.gameObject; 
    }
    void Update()
    {
        if (transform.position.x < (camera_Transform.transform.position.x - 50))
        {
            Destroy(gameObject);
        }
    }
}
