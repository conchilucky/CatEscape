using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomGenerator : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject[] levelPartsMisils;
    [SerializeField] private GameObject[] levelPartsRays;
    [SerializeField] private GameObject[] levelColect;
    [SerializeField] private GameObject[] PowerUps;
    [SerializeField] private GameObject[] GravedadBotas;
    [SerializeField] private GameObject[] Edificios;
    [SerializeField] private GameObject[] TechoNubes;
    [SerializeField] private GameObject[] ImanGenerator;
    [SerializeField] private GameObject[] ArbolesMuertos;

    public GameObject  levelStaticRays;
    public GameObject ratonDorado;

    public int generateRays, generateColect, generateMisils, generateStaticRays, generatePowerUps, generateEdificios, generateRatonDorado, generateGravedadBotas, generateTechoNubes, generateIman, generateArbol;
    public bool isGenerating, isGeneratingRays, isGeneratingMisils, isGeneratingColect, isGeneratingStaticRays, isGeneratingPowerUps, isGeneratingEdificios, isGeneratingRatonDorado, isGeneratingGravedadBotas,isGeneratingTechoNubes, isGeneratingIman, isGeneratingArbol;

    public Transform camera_Transform;

    public bool Generating = false;
    public bool GeneratingPowerUps = false;

    private float UltimaPosEdificio;
    private float UltimaPosArbol;
    private float UltimaPosNubes;

    public float TiempoRespawnRay = 3;

    public CharacterController3D playerControler;
    #endregion
    #region UnityMethods
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "ModoPerderVide" || SceneManager.GetActiveScene().name == "SampleScene")
        {
            levelStaticRays.SetActive(false);
        }    
        GenerateEdificios();
    }
    void Update()
    {
        if (Generating == false)
        {
            Generating = true;
            int randomNumber = Random.Range(0, 2);
            switch (randomNumber)
            {
                case 0:
                    StartCoroutine(GenerateLevelRays());
                 
                    break;
                case 1:
                    StartCoroutine(GenerateColect());

                    break;
            }
        }
        if (GeneratingPowerUps == false)
        {
            GeneratingPowerUps = true;
            int randomNumberPower = Random.Range(0, 2);
            switch (randomNumberPower)
            {
                case 0:

                    isGeneratingPowerUps = true;
                    StartCoroutine(GeneratePowerUps());
                    break;
                case 1:

                    isGeneratingGravedadBotas = true;
                    StartCoroutine(GenerateGravedadBotas());
                    break;
            }
        }
        if (isGeneratingRatonDorado == false)
        {
            isGeneratingRatonDorado = true;
            StartCoroutine(GenerateRatonDorado());
        }
        if (isGeneratingEdificios == false &&  UltimaPosEdificio  < (camera_Transform.position.x+57))
        {
            isGeneratingEdificios = true;
            GenerateEdificios();
        }
        if (isGeneratingTechoNubes == false && UltimaPosNubes < (camera_Transform.position.x + 57))
        {
            isGeneratingTechoNubes = true;
            GenerateNubesTecho();
        }
        if (isGeneratingMisils == false)
        {
            isGeneratingMisils = true;
            StartCoroutine(GenerateMisils());
        }
        if (isGeneratingStaticRays == false)
        {
            isGeneratingStaticRays = true;
            StartCoroutine(GenerateStaticRays());
        }
        if (isGeneratingIman == false)
        {
            isGeneratingIman = true;
            StartCoroutine(GenerateIman());
        }
        if (isGeneratingArbol == false && UltimaPosArbol < (camera_Transform.position.x + 57))
        {
            isGeneratingArbol = true;
            GenerateArbolMuerto();
        }
    }
    #endregion
    #region OwnMethods
    void GenerateEdificios()
    {
        generateEdificios = Random.Range(0, 1);
        GameObject instancia =  Instantiate(Edificios[generateEdificios], new Vector3(UltimaPosEdificio + 108, 12.5f, 40), Quaternion.identity);
         UltimaPosEdificio = instancia.transform.position.x;
         isGeneratingEdificios = false;
    }
    void GenerateNubesTecho()
    {
        generateTechoNubes = Random.Range(0, 1);
        if(playerControler.gravedadInvertida == true)
        {
            GameObject instanciaNube = Instantiate(TechoNubes[generateTechoNubes], new Vector3(UltimaPosNubes + 108, 1, 0), Quaternion.identity);
            UltimaPosNubes = instanciaNube.transform.position.x;
        }
        isGeneratingTechoNubes = false;
    }
    IEnumerator GenerateLevelRays()
    {
        if (SceneManager.GetActiveScene().name == "ModoPerderVide" || SceneManager.GetActiveScene().name == "SampleScene")
        {
            generateRays = Random.Range(0, 4);
            if (generateRays == 3)
            {
                Instantiate(levelPartsRays[generateRays], new Vector3(camera_Transform.position.x + 20, Random.Range(1.7f, 5), 0), Quaternion.identity);
            }
            else
            {
                Instantiate(levelPartsRays[generateRays], new Vector3(camera_Transform.position.x + 20, Random.Range(1.7f, 5), 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(Random.Range(TiempoRespawnRay, TiempoRespawnRay + 1));
            if (TiempoRespawnRay > 0.5)
            {
                TiempoRespawnRay -= 0.5f;
            }
            isGeneratingRays = false;
            Generating = false;
        }      
    }
    IEnumerator GenerateColect()
    {
        generateColect = Random.Range(0, 3);

        if(generateColect == 0)
        {
            Instantiate(levelColect[generateColect], new Vector3(camera_Transform.position.x + 30, Random.Range(-1.51f, 6), 0), Quaternion.identity);
        }
        if (generateColect == 1)
        {
            Instantiate(levelColect[generateColect], new Vector3(camera_Transform.position.x + 30, Random.Range(-0.03f, 6), 0), Quaternion.identity);
        }
        if (generateColect == 2)
        {
            Instantiate(levelColect[generateColect], new Vector3(camera_Transform.position.x + 30, Random.Range(1, 6), 0), Quaternion.identity);
        }
        if (generateColect == 3)
        {
            Instantiate(levelColect[generateColect], new Vector3(camera_Transform.position.x + 30, Random.Range(-0.50f, 5), 0), Quaternion.identity);
        }
        yield return new WaitForSeconds(Random.Range(1, 2));
        isGeneratingColect = false;
        Generating = false;
    }
    IEnumerator GenerateMisils()
    {
        yield return new WaitForSeconds(4);
        generateMisils = Random.Range(0, 1);
        Instantiate(levelPartsMisils[generateMisils], new Vector3(camera_Transform.position.x + 20, Random.Range(-3, 5), 0), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(10, 20));
        isGeneratingMisils = false;
    }
    IEnumerator GenerateStaticRays()
    {
        if (SceneManager.GetActiveScene().name == "ModoPerderVide" || SceneManager.GetActiveScene().name == "SampleScene")
        {
            yield return new WaitForSeconds(15);
            levelStaticRays.SetActive(true);
            yield return new WaitForSeconds(7);
            levelStaticRays.SetActive(false);
            isGeneratingStaticRays = false;
        }
    }
    IEnumerator GeneratePowerUps()
    {
        generatePowerUps = Random.Range(0, 1);
        if (playerControler.isEscudoActive == false && playerControler.gravedadInvertida == false)
        {
            Instantiate(PowerUps[generatePowerUps], new Vector3(camera_Transform.position.x + 30, Random.Range(-0.86f, 6), 0), Quaternion.identity);
        }
        yield return new WaitForSeconds(20);
        isGeneratingPowerUps = false;
        GeneratingPowerUps = false;
    }
    IEnumerator GenerateGravedadBotas()
    {
        if (SceneManager.GetActiveScene().name == "ModoPerderVide" || SceneManager.GetActiveScene().name == "SampleScene")
        {
            generateGravedadBotas = Random.Range(0, 1);
            if (playerControler.gravedadInvertida == false && playerControler.isEscudoActive == false)
            {
                Instantiate(GravedadBotas[generateGravedadBotas], new Vector3(camera_Transform.position.x + 30, Random.Range(-1.36f, 6), 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(15);
            isGeneratingGravedadBotas = false;
            GeneratingPowerUps = false;
        }
       
    }
    IEnumerator GenerateRatonDorado()
    {
        generateRatonDorado = Random.Range(0, 1);
        Instantiate(ratonDorado, new Vector3(camera_Transform.position.x + 30, Random.Range(1, 3), 0), Quaternion.identity);

        yield return new WaitForSeconds(40);
        isGeneratingRatonDorado = false;
    }
    IEnumerator GenerateIman()
    {
        generateIman = Random.Range(0, 1);
        Instantiate(ImanGenerator[generateIman], new Vector3(camera_Transform.position.x + 30, Random.Range(1, 3), 0), Quaternion.identity);
        yield return new WaitForSeconds(25);
        isGeneratingIman = false;
    }
    void GenerateArbolMuerto()
    {
        if (SceneManager.GetActiveScene().name == "FlapyCat")
        {
            generateArbol = Random.Range(0, 2);
            GameObject instancia = Instantiate(ArbolesMuertos[generateArbol], new Vector3(UltimaPosArbol + 60, 0, 34), Quaternion.identity);
            UltimaPosArbol = instancia.transform.position.x;
            isGeneratingArbol = false;
        }
    }
    #endregion
}
