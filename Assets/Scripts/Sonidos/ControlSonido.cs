using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSonido : MonoBehaviour
{
    #region Variables
    public GameObject botonON;
    public GameObject botonOFF;
    public Slider controlParaSonido;
    public float sliderValue;
    #endregion
    #region UnityMethods
    private void Start()
    {
        sliderValue = 1;
        controlParaSonido.value = PlayerPrefs.GetFloat("volumenAudio");
        AudioListener.volume = controlParaSonido.value;
    }
    #endregion
    #region OwnMethods
    public void ChangeSliderVolume()
    {
        sliderValue = controlParaSonido.value;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = controlParaSonido.value;
        Mute();
    }

    public void Mute()
    {
        if (sliderValue == 0)
        {
            botonOFF.SetActive(true);
            botonON.SetActive(false);
        }
        else if( sliderValue > 0)
        {
            botonON.SetActive(true);
            botonOFF.SetActive(false);
        }
    }

    public void On()
    {
        botonOFF.SetActive(false);
        sliderValue = 0;
        Debug.Log("desactivaSonido");
    }
    public void Off()
    {
        botonON.SetActive(false);
    }
    #endregion
}
