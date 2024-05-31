using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Recorrido : MonoBehaviour
{
    #region Variables
    //RECORRIDOTEXTO
    public Text textoRecorrido;
    public Text textoRecorridoNivel2;
    public Text textoRecorridoNivel3;

    //RECORRIDOACTUAL
    public static float recorrido;
    public static float recorridoNivel2;
    public static float recorridoNivel3;

    //HIGSCORETEXTO
    public Text textoMayorRecorrido;
    public Text textoMayorRecorridoFelicidades;

    public Text textoMayorRecorrido2;
    public Text textoMayorRecorridoFelicidades2;

    public Text textoMayorRecorrido3;
    public Text textoMayorRecorridoFelicidades3;

    //HIGSCORE
    public static float Mayorrecorrido;
    public static float MayorrecorridoNivel2;
    public static float MayorrecorridoNivel3;

    public Text textoFelicidadesRecorrido;
    public Text textoFelicidadesRecorrido2;
    public Text textoFelicidadesRecorrido3;

    public Transform player;
    public LevelData levelData;
    #endregion
    #region UnityMethods
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            Mayorrecorrido = PlayerPrefs.GetFloat("Highscore");
            if (textoMayorRecorrido != null)
            {
                textoMayorRecorrido.text = "Record Actual: " + levelData.distanciaRecord.ToString();
            }
        }
        if (SceneManager.GetActiveScene().name == "ModoPerderVide")
        {
            MayorrecorridoNivel2 = PlayerPrefs.GetFloat("HighscoreNivel2");
            if (textoMayorRecorrido2 != null)
            {
                textoMayorRecorrido2.text = "Record Actual: " + levelData.distanciaRecord.ToString();
            }
        }
        if (SceneManager.GetActiveScene().name == "FlapyCat")
        {
            MayorrecorridoNivel3 = PlayerPrefs.GetFloat("HighscoreNivel3");

            if (textoMayorRecorrido3 != null)
            {
                textoMayorRecorrido3.text = "Record Actual: " + levelData.distanciaRecord.ToString();
            }
        }

    }
    void Update()
    {

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            recorrido = player.transform.position.x;

            if (textoRecorrido != null)
            {
                textoRecorrido.text = "Recorrido: " + recorrido.ToString("F0");
            }

        }
        if (SceneManager.GetActiveScene().name == "ModoPerderVide")
        {
            recorridoNivel2 = player.transform.position.x;

            if (textoRecorridoNivel2 != null)
            {
                textoRecorridoNivel2.text = "Recorrido: " + recorridoNivel2.ToString("F0");
            }

        }
        if (SceneManager.GetActiveScene().name == "FlapyCat")
        {
            recorridoNivel3 = player.transform.position.x;

            if (textoRecorridoNivel3 != null)
            {
                textoRecorridoNivel3.text = "Recorrido: " + recorridoNivel3.ToString("F0");
            }
        }
    }
    #endregion
    #region OwnMethods
    public void ActualizarHighscore()
    {
        Mayorrecorrido = PlayerPrefs.GetFloat("Highscore");

        if(recorrido >  Mayorrecorrido)
        {
            if (textoMayorRecorrido.text != null)
            {
                textoMayorRecorridoFelicidades.text = " ¡NUEVO RECORD! ";
                textoFelicidadesRecorrido.text =  recorrido.ToString("F0");
            }
            Mayorrecorrido = recorrido;
            PlayerPrefs.SetFloat("Highscore", Mayorrecorrido);
        }
    }
    public void ActualizarHighscore2()
    {
        MayorrecorridoNivel2 = PlayerPrefs.GetFloat("HighscoreNivel2");
        if (recorridoNivel2 > MayorrecorridoNivel2)
        {
            if (textoMayorRecorrido2.text != null)
            {
                textoMayorRecorridoFelicidades2.text = " ¡NUEVO RECORD! ";
                textoFelicidadesRecorrido2.text = recorridoNivel2.ToString("F0");
            }
            MayorrecorridoNivel2 = recorridoNivel2;
            PlayerPrefs.SetFloat("HighscoreNivel2", MayorrecorridoNivel2);
        }
    }
    public void ActualizarHighscore3()
    {
        MayorrecorridoNivel3 = PlayerPrefs.GetFloat("HighscoreNivel3");
        if (recorridoNivel3 > MayorrecorridoNivel3)
        {
            if (textoMayorRecorrido3.text != null)
            {
                textoMayorRecorridoFelicidades3.text = " ¡NUEVO RECORD! ";
                textoFelicidadesRecorrido3.text = recorridoNivel3.ToString("F0");
            }
            MayorrecorridoNivel3 = recorridoNivel3;
            PlayerPrefs.SetFloat("HighscoreNivel3", MayorrecorridoNivel3);
        }

    }
    #endregion
}
