using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarMaterialSkin : MonoBehaviour
{
    #region Variables
    public GameObject playerSkinTienda;
    public static int numberMaterialTienda;
    public Material naranjaT, blancoT, negroT, siamesT, grisT, michiT, rayasT;

    public ManageTienda manageTienda;
    public SQliteTienda sQliteTienda;
    #endregion
    #region UnityMethods
    private void Start()
    {
        manageTienda = GameObject.FindGameObjectWithTag("TiendaCanva").GetComponent<ManageTienda>();
        playerSkinTienda.GetComponent<SkinnedMeshRenderer>().material = naranjaT;

        if (SQliteTienda.colorEquipado == "Naranja")
        {
            SkinNaranja();
        }
        else if (SQliteTienda.colorEquipado == "Blanco")
        {
            SkinBlanco();
        }
        else if (SQliteTienda.colorEquipado == "Negro")
        {
           SkinNegro();
        }
        else if (SQliteTienda.colorEquipado == "Siames")
        {
           SkinSiames();
        }
        else if (SQliteTienda.colorEquipado == "Gris")
        {
            SkinGris();
        }
        else if (SQliteTienda.colorEquipado == "Michi")
        {
            SkinMichi();
        }
        else if (SQliteTienda.colorEquipado == "Rayas")
        {
            SkinRayas();
        }
    }

    private void Update()
    {
        if (numberMaterialTienda == 0)
        {
            SkinNaranja();

            manageTienda.BotonEquiparNaranja.SetActive(true);

            manageTienda.BotonEquiparNegro.SetActive(false);
            manageTienda.BotonComprarNegro.SetActive(false);
            manageTienda.BotonEquiparBlanco.SetActive(false);
            manageTienda.BotonComprarBlanco.SetActive(false);
            manageTienda.BotonEquiparSiames.SetActive(false);
            manageTienda.BotonComprarSiames.SetActive(false);
            manageTienda.BotonEquiparGris.SetActive(false);
            manageTienda.BotonComprarGris.SetActive(false);
            manageTienda.BotonEquiparMichi.SetActive(false);
            manageTienda.BotonComprarMichi.SetActive(false);
            manageTienda.BotonEquiparRayas.SetActive(false);
            manageTienda.BotonComprarRayas.SetActive(false);


        }
        else if (numberMaterialTienda == 1)
        {
            SkinBlanco();

            if (manageTienda.tieneLaSkinBlancaComprada == true)
            {
                manageTienda.BotonEquiparBlanco.SetActive(true);
                manageTienda.BotonComprarBlanco.SetActive(false);

                manageTienda.BotonEquiparNegro.SetActive(false);
                manageTienda.BotonComprarNegro.SetActive(false);
                manageTienda.BotonEquiparNaranja.SetActive(false);
                manageTienda.BotonEquiparSiames.SetActive(false);
                manageTienda.BotonComprarSiames.SetActive(false);
                manageTienda.BotonEquiparGris.SetActive(false);
                manageTienda.BotonComprarGris.SetActive(false);
                manageTienda.BotonEquiparMichi.SetActive(false);
                manageTienda.BotonComprarMichi.SetActive(false);
                manageTienda.BotonEquiparRayas.SetActive(false);
                manageTienda.BotonComprarRayas.SetActive(false);
            }
            else
            {
                manageTienda.BotonComprarBlanco.SetActive(true);
                manageTienda.BotonEquiparBlanco.SetActive(false);

                manageTienda.BotonEquiparNegro.SetActive(false);
                manageTienda.BotonComprarNegro.SetActive(false);
                manageTienda.BotonEquiparNaranja.SetActive(false);
                manageTienda.BotonEquiparSiames.SetActive(false);
                manageTienda.BotonComprarSiames.SetActive(false);
                manageTienda.BotonEquiparGris.SetActive(false);
                manageTienda.BotonComprarGris.SetActive(false);
                manageTienda.BotonEquiparMichi.SetActive(false);
                manageTienda.BotonComprarMichi.SetActive(false);
                manageTienda.BotonEquiparRayas.SetActive(false);
                manageTienda.BotonComprarRayas.SetActive(false);
            }


        }
        else if (numberMaterialTienda == 2)
        {
            SkinNegro();

            if (manageTienda.tieneLaSkinNegraComprada == true)
            {
                manageTienda.BotonEquiparNegro.SetActive(true);
                manageTienda.BotonComprarNegro.SetActive(false);

                manageTienda.BotonEquiparBlanco.SetActive(false);
                manageTienda.BotonComprarBlanco.SetActive(false);
                manageTienda.BotonEquiparNaranja.SetActive(false);
                manageTienda.BotonEquiparSiames.SetActive(false);
                manageTienda.BotonComprarSiames.SetActive(false);
                manageTienda.BotonEquiparGris.SetActive(false);
                manageTienda.BotonComprarGris.SetActive(false);
                manageTienda.BotonEquiparMichi.SetActive(false);
                manageTienda.BotonComprarMichi.SetActive(false);
                manageTienda.BotonEquiparRayas.SetActive(false);
                manageTienda.BotonComprarRayas.SetActive(false);
            }
            else
            {
                manageTienda.BotonComprarNegro.SetActive(true);
                manageTienda.BotonEquiparNegro.SetActive(false);

                manageTienda.BotonEquiparBlanco.SetActive(false);
                manageTienda.BotonComprarBlanco.SetActive(false);
                manageTienda.BotonEquiparNaranja.SetActive(false);
                manageTienda.BotonEquiparSiames.SetActive(false);
                manageTienda.BotonComprarSiames.SetActive(false);
                manageTienda.BotonEquiparGris.SetActive(false);
                manageTienda.BotonComprarGris.SetActive(false);
                manageTienda.BotonEquiparMichi.SetActive(false);
                manageTienda.BotonComprarMichi.SetActive(false);
                manageTienda.BotonEquiparRayas.SetActive(false);
                manageTienda.BotonComprarRayas.SetActive(false);
            }
        }
        else if (numberMaterialTienda == 3)
        {
            SkinSiames();

            if (manageTienda.tieneLaSkinSiamesComprada == true)
            {
                manageTienda.BotonEquiparSiames.SetActive(true);
                manageTienda.BotonComprarSiames.SetActive(false);

                manageTienda.BotonEquiparNegro.SetActive(false);
                manageTienda.BotonComprarNegro.SetActive(false);
                manageTienda.BotonEquiparBlanco.SetActive(false);
                manageTienda.BotonComprarBlanco.SetActive(false);
                manageTienda.BotonEquiparNaranja.SetActive(false);
                manageTienda.BotonEquiparGris.SetActive(false);
                manageTienda.BotonComprarGris.SetActive(false);
                manageTienda.BotonEquiparMichi.SetActive(false);
                manageTienda.BotonComprarMichi.SetActive(false);
                manageTienda.BotonEquiparRayas.SetActive(false);
                manageTienda.BotonComprarRayas.SetActive(false);
            }
            else
            {
                manageTienda.BotonEquiparSiames.SetActive(false);
                manageTienda.BotonComprarSiames.SetActive(true);


                manageTienda.BotonComprarNegro.SetActive(false);
                manageTienda.BotonEquiparNegro.SetActive(false);
                manageTienda.BotonEquiparBlanco.SetActive(false);
                manageTienda.BotonComprarBlanco.SetActive(false);
                manageTienda.BotonEquiparNaranja.SetActive(false);
                manageTienda.BotonEquiparGris.SetActive(false);
                manageTienda.BotonComprarGris.SetActive(false);
                manageTienda.BotonEquiparMichi.SetActive(false);
                manageTienda.BotonComprarMichi.SetActive(false);
                manageTienda.BotonEquiparRayas.SetActive(false);
                manageTienda.BotonComprarRayas.SetActive(false);
            }
        }
        else if (numberMaterialTienda == 4)
        {
            SkinGris();

            if (manageTienda.tieneLaSkinGrisComprada == true)
            {
                manageTienda.BotonEquiparGris.SetActive(true);
                manageTienda.BotonComprarGris.SetActive(false);

                manageTienda.BotonEquiparSiames.SetActive(false);
                manageTienda.BotonComprarSiames.SetActive(false);
                manageTienda.BotonEquiparNegro.SetActive(false);
                manageTienda.BotonComprarNegro.SetActive(false);
                manageTienda.BotonEquiparBlanco.SetActive(false);
                manageTienda.BotonComprarBlanco.SetActive(false);
                manageTienda.BotonEquiparNaranja.SetActive(false);
                manageTienda.BotonEquiparMichi.SetActive(false);
                manageTienda.BotonComprarMichi.SetActive(false);
                manageTienda.BotonEquiparRayas.SetActive(false);
                manageTienda.BotonComprarRayas.SetActive(false);

            }
            else
            {
                manageTienda.BotonEquiparGris.SetActive(false);
                manageTienda.BotonComprarGris.SetActive(true);

                manageTienda.BotonEquiparSiames.SetActive(false);
                manageTienda.BotonComprarSiames.SetActive(false);
                manageTienda.BotonComprarNegro.SetActive(false);
                manageTienda.BotonEquiparNegro.SetActive(false);
                manageTienda.BotonEquiparBlanco.SetActive(false);
                manageTienda.BotonComprarBlanco.SetActive(false);
                manageTienda.BotonEquiparNaranja.SetActive(false);
                manageTienda.BotonEquiparMichi.SetActive(false);
                manageTienda.BotonComprarMichi.SetActive(false);
                manageTienda.BotonEquiparRayas.SetActive(false);
                manageTienda.BotonComprarRayas.SetActive(false);

            }
        }
        else if (numberMaterialTienda == 5)
        {
            SkinMichi();

            if (manageTienda.tieneLaSkinMichiComprada == true)
            {
                manageTienda.BotonEquiparMichi.SetActive(true);
                manageTienda.BotonComprarMichi.SetActive(false);

                manageTienda.BotonEquiparGris.SetActive(false);
                manageTienda.BotonComprarGris.SetActive(false);
                manageTienda.BotonEquiparSiames.SetActive(false);
                manageTienda.BotonComprarSiames.SetActive(false);
                manageTienda.BotonEquiparNegro.SetActive(false);
                manageTienda.BotonComprarNegro.SetActive(false);
                manageTienda.BotonEquiparBlanco.SetActive(false);
                manageTienda.BotonComprarBlanco.SetActive(false);
                manageTienda.BotonEquiparNaranja.SetActive(false);  
                manageTienda.BotonEquiparRayas.SetActive(false);
                manageTienda.BotonComprarRayas.SetActive(false);

            }
            else
            {
                manageTienda.BotonEquiparMichi.SetActive(false);
                manageTienda.BotonComprarMichi.SetActive(true);

                manageTienda.BotonEquiparGris.SetActive(false);
                manageTienda.BotonComprarGris.SetActive(false);
                manageTienda.BotonEquiparSiames.SetActive(false);
                manageTienda.BotonComprarSiames.SetActive(false);
                manageTienda.BotonComprarNegro.SetActive(false);
                manageTienda.BotonEquiparNegro.SetActive(false);
                manageTienda.BotonEquiparBlanco.SetActive(false);
                manageTienda.BotonComprarBlanco.SetActive(false);
                manageTienda.BotonEquiparNaranja.SetActive(false);
                manageTienda.BotonEquiparRayas.SetActive(false);
                manageTienda.BotonComprarRayas.SetActive(false);

            }
        }
        else if (numberMaterialTienda == 6)
        {
            SkinRayas();

            if (manageTienda.tieneLaSkinRayasComprada == true)
            {
                manageTienda.BotonEquiparRayas.SetActive(true);
                manageTienda.BotonComprarRayas.SetActive(false);

                manageTienda.BotonEquiparMichi.SetActive(false);
                manageTienda.BotonComprarMichi.SetActive(false);
                manageTienda.BotonEquiparGris.SetActive(false);
                manageTienda.BotonComprarGris.SetActive(false);
                manageTienda.BotonEquiparSiames.SetActive(false);
                manageTienda.BotonComprarSiames.SetActive(false);
                manageTienda.BotonEquiparNegro.SetActive(false);
                manageTienda.BotonComprarNegro.SetActive(false);
                manageTienda.BotonEquiparBlanco.SetActive(false);
                manageTienda.BotonComprarBlanco.SetActive(false);
                manageTienda.BotonEquiparNaranja.SetActive(false);
              

            }
            else
            {
                manageTienda.BotonEquiparRayas.SetActive(false);
                manageTienda.BotonComprarRayas.SetActive(true);

                manageTienda.BotonEquiparMichi.SetActive(false);
                manageTienda.BotonComprarMichi.SetActive(false);
                manageTienda.BotonEquiparGris.SetActive(false);
                manageTienda.BotonComprarGris.SetActive(false);
                manageTienda.BotonEquiparSiames.SetActive(false);
                manageTienda.BotonComprarSiames.SetActive(false);
                manageTienda.BotonComprarNegro.SetActive(false);
                manageTienda.BotonEquiparNegro.SetActive(false);
                manageTienda.BotonEquiparBlanco.SetActive(false);
                manageTienda.BotonComprarBlanco.SetActive(false);
                manageTienda.BotonEquiparNaranja.SetActive(false);
                

            }
        }
    }
    #endregion
    #region OwnMethods
    public void SkinBlanco()
    {
        playerSkinTienda.GetComponent<SkinnedMeshRenderer>().material = blancoT;
        numberMaterialTienda = 1;
    }
    public void SkinNaranja()
    {
        playerSkinTienda.GetComponent<SkinnedMeshRenderer>().material = naranjaT;
        numberMaterialTienda = 0;
    }
    public void SkinNegro()
    {
        playerSkinTienda.GetComponent<SkinnedMeshRenderer>().material = negroT;
        numberMaterialTienda = 2;
    }
    public void SkinSiames()
    {
        playerSkinTienda.GetComponent<SkinnedMeshRenderer>().material = siamesT;
        numberMaterialTienda = 3;
    }
    public void SkinGris()
    {
        playerSkinTienda.GetComponent<SkinnedMeshRenderer>().material = grisT;
        numberMaterialTienda = 4;
    }
    public void SkinMichi()
    {
        playerSkinTienda.GetComponent<SkinnedMeshRenderer>().material = michiT;
        numberMaterialTienda = 5;
    }
    public void SkinRayas()
    {
        playerSkinTienda.GetComponent<SkinnedMeshRenderer>().material = rayasT;
        numberMaterialTienda = 6;
    }
    #endregion
}
