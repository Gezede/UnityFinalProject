using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource; // Ses çalacak olan AudioSource bileþeni

    private void Start()
    {
        // Eðer audioSource atanmadýysa, bu bileþeni kendisi al
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        // Ses dosyasýný çal
        if (audioSource != null)
            audioSource.Play();
    }
}

