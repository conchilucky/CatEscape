using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CharacterController3D : MonoBehaviour
{
    #region Variables
    private CharacterController controller;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    public float playerSpeed = 1.0f;
    public float jumpHeigth = 25f;
    public float gravityValue = -9f;
    public Animator anim;
    
    public int life = 10;

    private SceneManagementCapy manageScene;
    public BarraDeVida barraDeVida;
    public Recorrido recorridoScript;

    public float recorridoCapibara;
    public float distanciaSubir = 100;
    public float velocidadMax = 10;

    public bool isEscudoActive;
    public GameObject escudo;
    public GameObject gorrocoptero;
    public GameObject gorrocopteroAspas;

    public GameObject playerSkin;
    public static int numberMaterial;
    public Material naranja, blanco, negro, siames, gris, michi, rayas;

    public bool hasMuerto;

    public bool gravedadInvertida;
    public float positivonegativo;

    public GameObject botasGravedad;
    public GameObject botasGravedad1;
    public GameObject imanPlayer;
    public GameObject imanObjecto;
    public GameObject imanEfecto;

    public AudioClip audioGolpe;
    public LayerMask milayerMask;

    public ADSample adRecompensa;
    public LevelData levelData;
    public TotalCoins totalCoins;
    public SQliteTienda sQliteTienda;
    #endregion
    #region UnityMethods
    void Start()
    {
        imanPlayer.SetActive(false);
        imanEfecto.SetActive(false);
        gorrocoptero.SetActive(true);
        gorrocopteroAspas.SetActive(true);
        hasMuerto = false;

        playerSkin.GetComponent<SkinnedMeshRenderer>().material = naranja;

        escudo.SetActive(false);

        life = 10;

        controller = gameObject.GetComponent<CharacterController>();
        if (SceneManager.GetActiveScene().name == "ModoPerderVide")
        {
            barraDeVida = GameObject.Find("CanvasSliderVida").GetComponent<BarraDeVida>();
        }
        
        manageScene = GameObject.FindGameObjectWithTag("SceneManage").GetComponent<SceneManagementCapy>();
        recorridoCapibara = transform.position.x;
        //Skins De Personaje
        if (SQliteTienda.colorEquipado == "Naranja")
        {
            ChangeSkinNaranja();
        }
        else if (SQliteTienda.colorEquipado == "Blanco")
        {
            ChangeSkinBlanco();
        }
        else if (SQliteTienda.colorEquipado == "Negro")
        {
            ChangeSkinNegro();
        }
        else if (SQliteTienda.colorEquipado == "Siames")
        {
            ChangeSkinSiames();
        }
        else if (SQliteTienda.colorEquipado == "Gris")
        {
            ChangeSkinGris();
        }
        else if (SQliteTienda.colorEquipado == "Michi")
        {
            ChangeSkinMichi();
        }
        else if (SQliteTienda.colorEquipado == "Rayas")
        {
            ChangeSkinRayas();
        }
    }
    void Update()
    {
        //Invertir gravedad
        if (gravedadInvertida == true)
        {
            positivonegativo = -1;
            botasGravedad.SetActive(true);
            botasGravedad1.SetActive(true);
            transform.localScale =  new Vector3(1, -1, 1);
        }
        else
        {
            positivonegativo = 1;
            botasGravedad.SetActive(false);
            botasGravedad1.SetActive(false);
            transform.localScale = new Vector3(1, 1, 1);
        }

        groundedPlayer = Physics.Raycast(transform.position, -Vector3.up * positivonegativo,  0.05f, milayerMask );
        if (groundedPlayer)
        {
            playerVelocity.y = 0f;
        }
        if(groundedPlayer)
        {
            anim.SetBool("EstaVolando", false);
        }
        //Movimiento

        if(hasMuerto == false)
        {
            Vector3 move = new Vector3(1, 0, 0);
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero && hasMuerto == false)
            {
                gameObject.transform.forward = move;
            }
        }
        //Aumento de Velocidad

        if(transform.position.x > (recorridoCapibara + distanciaSubir))
        {
            if (controller.velocity.x < velocidadMax)
            {
                AumentaVelocidadMovimiento();
                recorridoCapibara = transform.position.x;
            }
        }

        //Salto

        if (Time.timeScale > 0)
        {
            if (gravedadInvertida == false)
            {
                if (Input.GetButtonDown("Fire1") && hasMuerto == false && transform.position.y <= 6.2f)
                {

                    playerVelocity.y += Mathf.Sqrt(jumpHeigth * -3.0f * gravityValue) * positivonegativo;
                    anim.SetBool("EstaVolando", true);
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1") && hasMuerto == false)
                {

                    playerVelocity.y += Mathf.Sqrt(jumpHeigth * -3.0f * gravityValue) * positivonegativo;
                    anim.SetBool("EstaVolando", true);
                }
            }

        }

        playerVelocity.y += (gravityValue * Time.deltaTime * positivonegativo);
        controller.Move(playerVelocity * Time.deltaTime);

        //Activar y Desactivar Escudo

        if (isEscudoActive && life == 10)
        {
            isEscudoActive = false;
            escudo.SetActive(false);
        }
        else if(isEscudoActive && life == 20)
        {
            isEscudoActive = true;
            escudo.SetActive(true);
        }

        //Límitite de Salto

        if(gravedadInvertida == false)
        {
            if (transform.position.y >= 6.2f)
            {
                playerVelocity.y = 0;
                transform.position = new Vector3(transform.position.x, 6.1f, transform.position.z);
            }
        }
        else if (gravedadInvertida == true)
        {
            if (transform.position.y <= -0.22f)
            {
                playerVelocity.y = 0;
                transform.position = new Vector3(transform.position.x, -0.11f, transform.position.z);
            }
        }

        //Barra de vida

        if (barraDeVida != null)
        {
          if (barraDeVida.vidaActual == 0)
          {
                barraDeVida.vidaActual = 0;
                GameOver();
                StartCoroutine(EsperarAMuerte());
          }
        }
    }
    #endregion
    #region OwnMethods
    public void Restardlife(int cantidad)
    {
        ControladorSonido.Instance.EjecutarSonido(audioGolpe);
        life -= 10;
        if(gravedadInvertida == true)
        {
            gravedadInvertida = false;
        }
        if (life == 0)
        {
            GameOver();
            StartCoroutine(EsperarAMuerte());    
        }  
    }
    void GameOver()
    {
        gorrocoptero.SetActive(false);
        gorrocopteroAspas.SetActive(false);
        imanEfecto.SetActive(false);
        anim.SetBool("HaMuerto", true);
        hasMuerto = true;
        totalCoins.totalCoins += investario.CantidadMandarina;
        ManagerGuardo.Instance.Save();
        SaveLevelData();
    }
    public void SaveLevelData()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene" && levelData.distanciaRecord < Recorrido.recorrido)
        {
            levelData.distanciaRecord = (int)Recorrido.recorrido;
        }

        if (SceneManager.GetActiveScene().name == "ModoPerderVide" && levelData.distanciaRecord < Recorrido.recorridoNivel2)
        {
            levelData.distanciaRecord = (int)Recorrido.recorridoNivel2;
        }

        if (SceneManager.GetActiveScene().name == "FlapyCat" && levelData.distanciaRecord < Recorrido.recorridoNivel3)
        {
            levelData.distanciaRecord = (int)Recorrido.recorridoNivel3;
        }
        ManagerGuardo.Instance.Save();
    }
    public void ReaparecerGameOver()
    {
        manageScene.DesactivarAnuncio();
        manageScene.ActivarBotonPausa();

        gorrocoptero.SetActive(true);
        gorrocopteroAspas.SetActive(true);
        imanEfecto.SetActive(false);
        anim.SetBool("HaMuerto", false);
        hasMuerto = false;

        Time.timeScale = 1;

        isEscudoActive = true;
        escudo.SetActive(true);
        life = 20;

        if (barraDeVida != null)
        {
            barraDeVida.vidaActual = barraDeVida.vidaMáxima;
            barraDeVida.isChangingLive = false;
        }
        if (adRecompensa.heConseguidoLaRecompensa == true)
        {
            StopAllCoroutines();
        }
    }
    IEnumerator EsperarAMuerte()
    {
        yield return new WaitForSeconds(5);

        Time.timeScale = 0;

        manageScene.DesactivarBotonPausa();

        if (SceneManager.GetActiveScene().name == "SampleScene" || SceneManager.GetActiveScene().name == "ModoPerderVide")
        {
            if (adRecompensa.heConseguidoLaRecompensa == false)
            {
                manageScene.ActivarAnuncio();

                yield return new WaitForSecondsRealtime(5);


                manageScene.DesactivarAnuncio();

                if (adRecompensa.hasVistoElVideo == true)
                {
                    yield break;
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (Recorrido.recorrido > Recorrido.Mayorrecorrido)
            {
                manageScene.ActivarNuevoHigscore();
                recorridoScript.ActualizarHighscore();

            }
            else if (Recorrido.recorrido < Recorrido.Mayorrecorrido)
            {

                manageScene.ActivarGameOver();
            }
        }

        if (SceneManager.GetActiveScene().name == "ModoPerderVide")
        {
            if (Recorrido.recorridoNivel2 > Recorrido.MayorrecorridoNivel2)
            {
                manageScene.ActivarNuevoHigscore();
                recorridoScript.ActualizarHighscore2();

            }
            else if (Recorrido.recorridoNivel2 < Recorrido.MayorrecorridoNivel2)
            {

                manageScene.ActivarGameOver();
            }

        }

        if (SceneManager.GetActiveScene().name == "FlapyCat")
        {
            if (Recorrido.recorridoNivel3 > Recorrido.MayorrecorridoNivel3)
            {
                manageScene.ActivarNuevoHigscore();
                recorridoScript.ActualizarHighscore3();
            }
            else if (Recorrido.recorridoNivel3 < Recorrido.MayorrecorridoNivel3)
            {
                manageScene.ActivarGameOver();
            }
        }

    }
    void AumentaVelocidadMovimiento()
    { 
       playerSpeed += 1;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EscudoPowerUp" && hasMuerto == false)
        {
            isEscudoActive = true;
            escudo.SetActive(true);
            investario.CantidadPowerUpEscudo += 1;
            life = 20;
        }

        if (other.tag == "ImanObj")
        {
            imanObjecto = GameObject.Find("ImanBaja_3DS");
            imanPlayer.SetActive(true);
            imanEfecto.SetActive(true);
            Destroy(imanObjecto);

            StartCoroutine(EsperaCambiaIman());
        }
    }
    IEnumerator EsperaCambiaIman()
    {
        yield return new WaitForSeconds(10);
        imanPlayer.SetActive(false);
        imanEfecto.SetActive(false);
    }
    public void ChangeSkinBlanco()
    {
        playerSkin.GetComponent<SkinnedMeshRenderer>().material = blanco;
        numberMaterial = 1;
    }
    public void ChangeSkinNaranja()
    {
        playerSkin.GetComponent<SkinnedMeshRenderer>().material = naranja;
        numberMaterial = 0;
    }
    public void ChangeSkinNegro()
    {
        playerSkin.GetComponent<SkinnedMeshRenderer>().material = negro;
        numberMaterial = 2;
    }
    public void ChangeSkinSiames()
    {
        playerSkin.GetComponent<SkinnedMeshRenderer>().material = siames;
        numberMaterial = 3;
    }
    public void ChangeSkinGris()
    {
        playerSkin.GetComponent<SkinnedMeshRenderer>().material = gris;
        numberMaterial = 4;
    }
    public void ChangeSkinMichi()
    {
        playerSkin.GetComponent<SkinnedMeshRenderer>().material = michi;
        numberMaterial = 5;
    }
    public void ChangeSkinRayas()
    {
        playerSkin.GetComponent<SkinnedMeshRenderer>().material = rayas;
        numberMaterial = 6;
    }
    #endregion
}
