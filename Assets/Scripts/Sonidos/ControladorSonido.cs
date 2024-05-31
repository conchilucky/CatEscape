using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSonido : MonoBehaviour
{

    public static ControladorSonido Instance;
    public AudioSource audioSource;
    public AudioClip coinCollectedClip;
    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        investario.OnCoinCollected += CollectedCoinSound;
    }
    private void OnDisable()
    {
        investario.OnCoinCollected -= CollectedCoinSound;
    }
    public void EjecutarSonido(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }
    public void PausarMusica()
    {
        audioSource.Stop();
    }
    public void CollectedCoinSound()
    {
        audioSource.PlayOneShot(coinCollectedClip, 0.5f);
    }
}
