using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RatonDorado : MonoBehaviour
{
    #region Variables
    public BarraDeVida barraVida;
    public GameObject[] wayPoints;
    float velocity = 5;
    int wayPointsIndex = 0;
    public CharacterController3D player_script;
    public Transform platform;
    #endregion
    #region UnityMethods
    private void Start()
    {
       player_script = GameObject.Find("T-Pose").GetComponent<CharacterController3D>();

       if (SceneManager.GetActiveScene().name == "ModoPerderVide")
       {
            barraVida = GameObject.Find("CanvasSliderVida").GetComponent<BarraDeVida>();
       }
    }
    private void Update()
    {
        velocity = player_script.playerSpeed;
        StartCoroutine(MoveMouse());
    }
    #endregion
    #region OwnMethods
    IEnumerator MoveMouse()
    {
        yield return new WaitForSeconds(2);
        if( Vector3.Distance(platform.transform.position, wayPoints[wayPointsIndex].transform.position) < 0.1f)
        {
            if(wayPointsIndex < wayPoints.Length)
            {
                wayPointsIndex++;
            }
        }
        if(wayPointsIndex >= wayPoints.Length)
        {
            wayPointsIndex = 0;
        }
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, wayPoints[wayPointsIndex].transform.position, (velocity -1)* Time.deltaTime);
        transform.Translate(Vector3.right * Time.deltaTime * (velocity - 1), Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            investario.CantidadMandarina += 10;
            if (barraVida != null)
            {
                barraVida.vidaActual += 5;
            }
            Destroy(gameObject);
        }
    }
    #endregion
}
