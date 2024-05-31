using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageTienda : MonoBehaviour
{
    #region Variables
    public Text CantidadRatonesTexto;

    public int precioSkinBlanca = 4, precioSkinNegra = 600, precioSkinSiames = 800, precioSkinGris = 1000, precioSkinMichi = 1200, precioSkinRayas = 1000;

    public GameObject BotonEquiparBlanco, BotonEquiparNegro, BotonEquiparNaranja, BotonEquiparSiames, BotonEquiparGris, BotonEquiparMichi, BotonEquiparRayas;
    public GameObject BotonComprarBlanco, BotonComprarNegro, BotonComprarSiames, BotonComprarGris, BotonComprarMichi, BotonComprarRayas;

    public bool tieneLaSkinBlancaComprada, tieneLaSkinNegraComprada, tieneLaSkinSiamesComprada, tieneLaSkinGrisComprada, tieneLaSkinMichiComprada, tieneLaSkinRayasComprada;
    public int SkinBlancaAdquirida, SkinNegraAdquirida, SkinSiamesAdquirida, SkinGrisAdquirida, SkinMichiAdquirida, SkinRayasAdquirida;

    public bool tieneLaSkinNaranjaComprada = true;

    public SQliteTienda sQliteTienda;
    public TotalCoins totalCoinsScript;

    #endregion
    #region UnityMethods
    private void Update()
    {
        CantidadRatonesTexto.text = ": " + totalCoinsScript.totalCoins.ToString();
    }
    #endregion
    #region OwnMethods
    public void ComprarSkinBlanco()
    {
        if (totalCoinsScript.totalCoins >= precioSkinBlanca)
        {
            totalCoinsScript.totalCoins = totalCoinsScript.totalCoins - precioSkinBlanca;
            BotonComprarBlanco.SetActive(false);
            BotonEquiparBlanco.SetActive(true);

            SQliteTienda.color = "Blanco";
            tieneLaSkinBlancaComprada = true;
        } 
    }
    public void ComprarSkinSiames()
    {
        if (totalCoinsScript.totalCoins >= precioSkinSiames)
        {
            totalCoinsScript.totalCoins = totalCoinsScript.totalCoins - precioSkinSiames;
            BotonComprarSiames.SetActive(false);
            BotonEquiparSiames.SetActive(true);

            SQliteTienda.color = "Siames";
            tieneLaSkinSiamesComprada = true;
        }
    }
    public void ComprarSkinGris()
    {
        if (totalCoinsScript.totalCoins >= precioSkinGris)
        {
            totalCoinsScript.totalCoins = totalCoinsScript.totalCoins - precioSkinGris;
            BotonComprarGris.SetActive(false);
            BotonEquiparGris.SetActive(true);

            SQliteTienda.color = "Gris";
            tieneLaSkinGrisComprada = true;
        }
    }
    public void ComprarSkinMichi()
    {
        if (totalCoinsScript.totalCoins >= precioSkinMichi)
        {
            totalCoinsScript.totalCoins = totalCoinsScript.totalCoins - precioSkinMichi;
            BotonComprarMichi.SetActive(false);
            BotonEquiparMichi.SetActive(true);

            SQliteTienda.color = "Michi";
            tieneLaSkinMichiComprada = true;
        }
    }
    public void ComprarSkinRayas()
    {
        if (totalCoinsScript.totalCoins >= precioSkinRayas)
        {
            totalCoinsScript.totalCoins = totalCoinsScript.totalCoins - precioSkinRayas;
            BotonComprarRayas.SetActive(false);
            BotonEquiparRayas.SetActive(true);

            SQliteTienda.color = "Rayas";
            tieneLaSkinRayasComprada = true;
        }
    }
    public void ComprarSkinNegra()
    {
        if (totalCoinsScript.totalCoins >= precioSkinNegra)
        {
            totalCoinsScript.totalCoins = totalCoinsScript.totalCoins - precioSkinNegra;
            BotonComprarNegro.SetActive(false);
            BotonEquiparNegro.SetActive(true);

            SQliteTienda.color = "Negro";
            tieneLaSkinNegraComprada = true;
        }
    }
    public void EquiparSkinBlanco()
    {
        CharacterController3D.numberMaterial = 1;
        SQliteTienda.colorEquipado = "Blanco";
    }
    public void EquiparSkinNegra()
    {
        CharacterController3D.numberMaterial = 2;
        SQliteTienda.colorEquipado = "Negro";
    }
    public void EquiparSkinNaranja()
    {
        CharacterController3D.numberMaterial = 0;
        SQliteTienda.colorEquipado = "Naranja";
    }
    public void EquiparSkinSiames()
    {
        CharacterController3D.numberMaterial = 3;
        SQliteTienda.colorEquipado = "Siames";
    }
    public void EquiparSkinGris()
    {
        CharacterController3D.numberMaterial = 4;
        SQliteTienda.colorEquipado = "Gris";
    }
    public void EquiparSkinMichi()
    {
        CharacterController3D.numberMaterial = 5;
        SQliteTienda.colorEquipado = "Michi";
    }
    public void EquiparSkinRayas()
    {
        CharacterController3D.numberMaterial = 6;
        SQliteTienda.colorEquipado = "Rayas";
    }
    #endregion
}
