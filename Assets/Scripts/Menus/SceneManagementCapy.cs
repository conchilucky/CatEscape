using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagementCapy : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject menuGameOver;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menuAnuncio;
    [SerializeField] public GameObject menuNuevoHigscore;
    [SerializeField] private GameObject botoncitoPausaPequeño;
    [SerializeField] public GameObject barraParaVida;

    public Image circuloADSTiempo;
    public float tiempoAnuncioActual;
    public float tiempoAnuncioMax;
    public bool isChangingTime;
    public bool isMenuADSActivo;

    public CharacterController3D playerControler;

    public GameObject infoNivel1;
    public GameObject infoNivel2;
    public GameObject infoNivel3;
    public GameObject candadoImage;
    public  Button candadoBoton;
    public GameObject candadoImageFlapy;
    public Button candadoBotonFlapy;

    public ADSample adsampleScript;
    public AudioClip gameOver;
    #endregion
    #region UnityMethods
    private void Start()
    {
        isMenuADSActivo = false;
        tiempoAnuncioActual = tiempoAnuncioMax;

        if (SceneManager.GetActiveScene().name == "MenuPrincipal")
        {
            Recorrido.Mayorrecorrido = PlayerPrefs.GetFloat("Highscore");
            ManagerGuardo.Instance.Load();

            if (Recorrido.Mayorrecorrido >= 1000f)
            {
                ActivarSegundoNivel();
            }
            else if (Recorrido.Mayorrecorrido < 1000f)
            {
                DesactivarSegundoNivel();
            }
            if (Recorrido.Mayorrecorrido >= 2000f)
            {
                ActivarFlapyNivel();
            }
            else if (Recorrido.Mayorrecorrido < 2000f)
            {
                DesactivarFlapyNivel();
            }
        }
        if (SceneManager.GetActiveScene().name == "ModoPerderVide" || SceneManager.GetActiveScene().name == "SampleScene" || SceneManager.GetActiveScene().name == "FlapyCat")
        {
            playerControler = GameObject.Find("Player").GetComponent<CharacterController3D>();
        }
    }
    void Update()
    {
       if (isMenuADSActivo == true)
        {
            circuloADSTiempo.fillAmount = tiempoAnuncioActual / tiempoAnuncioMax;
            if (tiempoAnuncioActual >= 0)
            {
                tiempoAnuncioActual -= Time.unscaledDeltaTime;
            }
            else if (tiempoAnuncioActual <= 0)
            {
                tiempoAnuncioActual = 0;
            }
            DesactivarBarraVida();
       }
        if (isMenuADSActivo == false)
        {
            ActivarBarraVida();
        }
    }
    #endregion
    #region OwnMethods
    public void DesactivarBarraVida()
    {
        barraParaVida.SetActive(false);       
    }
    public void ActivarBarraVida()
    {
        if (SceneManager.GetActiveScene().name == "ModoPerderVide")
        {
            barraParaVida.SetActive(true);
        }
    }
    public void DesactivarBotonPausa()
    {
        botoncitoPausaPequeño.SetActive(false);
    }
    public void ActivarBotonPausa()
    {
        botoncitoPausaPequeño.SetActive(true);
    }
    public void ActivarGameOver()
    {
        menuGameOver.SetActive(true);
        if (SceneManager.GetActiveScene().name == "ModoPerderVide")
        {
            DesactivarBarraVida();
        }      
        ControladorSonido.Instance.PausarMusica();
        ControladorSonido.Instance.EjecutarSonido(gameOver);
    }
    public void ActivarAnuncio()
    {
        menuAnuncio.SetActive(true);
        isMenuADSActivo = true;
    }
    public void DesactivarAnuncio()
    {
        menuAnuncio.SetActive(false);
        isMenuADSActivo = false;
    }
    public void ActivarNuevoHigscore()
    {
        menuNuevoHigscore.SetActive(true);
        if (SceneManager.GetActiveScene().name == "ModoPerderVide")
        {
            DesactivarBarraVida();
        }
    }
    public void DesactivarNuevoHigscore()
    {
        menuNuevoHigscore.SetActive(false);
        Time.timeScale = 0;
        ActivarGameOver();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    public void MenuJuego(string nombre)
    {
        SceneManager.LoadScene(nombre);
        Time.timeScale = 1;
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void ActivarPausa()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
    }
    public void DesactivarPausa()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
    }
    public void MenuTienda(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void Info1()
    {
        StartCoroutine(MostrarInfo1());
    }
    IEnumerator MostrarInfo1()
    {
        infoNivel1.SetActive(true);
        yield return new WaitForSeconds(5);
        infoNivel1.SetActive(false);
    }
    public void Info2()
    {
        StartCoroutine(MostrarInfo2());
    }
    IEnumerator MostrarInfo2()
    {
        infoNivel2.SetActive(true);
        yield return new WaitForSeconds(5);
        infoNivel2.SetActive(false);
    }
    public void Info3()
    {
        StartCoroutine(MostrarInfo3());
    }
    IEnumerator MostrarInfo3()
    {
        infoNivel3.SetActive(true);
        yield return new WaitForSeconds(5);
        infoNivel3.SetActive(false);
    }
    public void ActivarSegundoNivel()
    {
        candadoBoton.enabled = true;
        candadoImage.SetActive(false);
    }
    public  void DesactivarSegundoNivel()
    {
        candadoBoton.enabled = false;
        candadoImage.SetActive(true);
    }
    public void ActivarFlapyNivel()
    {
        candadoBotonFlapy.enabled = true;
        candadoImageFlapy.SetActive(false);
    }
    public void DesactivarFlapyNivel()
    {
        candadoBotonFlapy.enabled = false;
        candadoImageFlapy.SetActive(true);
    }
    #endregion
}
