using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour
{
    public Rigidbody aracRigidbody; // Arac�n Rigidbody bile�eni
    public Text speedText; // Canvas �zerindeki metin kutusu

    private void Update()
    {
        // Arac�n h�z�n� al
        float aracHizi = aracRigidbody.velocity.magnitude;

        // H�z� metin olarak g�ncelle
        speedText.text = "Speed: " + aracHizi.ToString("F1") + " m/s"; // Metni g�ncelle, bir ondal�k basamakla s�n�rl� olarak
    }
}
