using System;
using UnityEngine;

public class investario : MonoBehaviour
{
    public static Action OnCoinCollected;
    public static int CantidadMandarina = 0;
    public static int CantidadPowerUpEscudo = 0;
    private void OnEnable()
    {
        OnCoinCollected += pickCoin;
    }
    private void OnDisable()
    {
        OnCoinCollected -= pickCoin;
    }
    private void Update()
    {
        Debug.Log(CantidadMandarina.ToString());
    }
    public void pickCoin()
    {
        CantidadMandarina++;
    }
}
