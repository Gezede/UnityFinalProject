using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource; // Ses �alacak olan AudioSource bile�eni

    private void Start()
    {
        // E�er audioSource atanmad�ysa, bu bile�eni kendisi al
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        // Ses dosyas�n� �al
        if (audioSource != null)
            audioSource.Play();
    }
}

