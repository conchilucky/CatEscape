using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    private CharacterController3D controllerPlayer;   
    private void Start()
    {
        controllerPlayer = GameObject.Find("T-Pose").GetComponent<CharacterController3D>();
    }
   void Update()
    {
       if(controllerPlayer.gravedadInvertida == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            controllerPlayer.gravedadInvertida = true;
            controllerPlayer.life = 20;           
            Destroy(gameObject);
        }
    }
}
