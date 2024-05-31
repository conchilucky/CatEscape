using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteraccionPowerUps : MonoBehaviour
{
    public GameObject powerUpEscudo;

    private CharacterController3D controllerPlayer;

    private void Start()
    {
        controllerPlayer = GameObject.Find("T-Pose").GetComponent<CharacterController3D>();
    }
    void Update()
    {
        if (controllerPlayer.isEscudoActive == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(powerUpEscudo);
        }
    }
}
