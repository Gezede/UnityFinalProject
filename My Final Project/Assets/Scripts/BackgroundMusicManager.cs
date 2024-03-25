using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicManager : MonoBehaviour
{
    public Slider sfxSlider; // SFX (efekt) sesi i�in slider
    public Slider musicSlider; // Arka plan m�zi�i i�in slider

    public AudioSource[] sfxSources; // SFX sesleri i�in ses kaynaklar�
    public AudioSource[] musicSources; // Arka plan m�zi�i i�in ses kaynaklar�

    public float minVolume = 0.1f; // Minimum ses seviyesi

    private void Start()
    {
        // Ba�lang��ta sliderlar�n de�erlerini mevcut ses seviyelerine g�re ayarla
        sfxSlider.value = 1f;
        musicSlider.value = 1f;
    }

    public void AdjustSFXVolume()
    {
        // Slider de�eri de�i�ti�inde SFX ses seviyesini ayarla
        float volume = sfxSlider.value;
        foreach (AudioSource sfxSource in sfxSources)
        {
            sfxSource.volume = Mathf.Lerp(minVolume, 1f, volume);
        }
    }

    public void AdjustMusicVolume()
    {
        // Slider de�eri de�i�ti�inde m�zik ses seviyesini ayarla
        float volume = musicSlider.value;
        foreach (AudioSource musicSource in musicSources)
        {
            musicSource.volume = Mathf.Lerp(minVolume, 1f, volume);
        }
    }
}