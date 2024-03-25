using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicManager : MonoBehaviour
{
    public Slider sfxSlider; // SFX (efekt) sesi için slider
    public Slider musicSlider; // Arka plan müziði için slider

    public AudioSource[] sfxSources; // SFX sesleri için ses kaynaklarý
    public AudioSource[] musicSources; // Arka plan müziði için ses kaynaklarý

    public float minVolume = 0.1f; // Minimum ses seviyesi

    private void Start()
    {
        // Baþlangýçta sliderlarýn deðerlerini mevcut ses seviyelerine göre ayarla
        sfxSlider.value = 1f;
        musicSlider.value = 1f;
    }

    public void AdjustSFXVolume()
    {
        // Slider deðeri deðiþtiðinde SFX ses seviyesini ayarla
        float volume = sfxSlider.value;
        foreach (AudioSource sfxSource in sfxSources)
        {
            sfxSource.volume = Mathf.Lerp(minVolume, 1f, volume);
        }
    }

    public void AdjustMusicVolume()
    {
        // Slider deðeri deðiþtiðinde müzik ses seviyesini ayarla
        float volume = musicSlider.value;
        foreach (AudioSource musicSource in musicSources)
        {
            musicSource.volume = Mathf.Lerp(minVolume, 1f, volume);
        }
    }
}