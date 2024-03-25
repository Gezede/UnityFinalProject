using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour
{
    public Rigidbody aracRigidbody; // Aracýn Rigidbody bileþeni
    public Text speedText; // Canvas üzerindeki metin kutusu

    private void Update()
    {
        // Aracýn hýzýný al
        float aracHizi = aracRigidbody.velocity.magnitude;

        // Hýzý metin olarak güncelle
        speedText.text = "Speed: " + aracHizi.ToString("F1") + " m/s"; // Metni güncelle, bir ondalýk basamakla sýnýrlý olarak
    }
}
