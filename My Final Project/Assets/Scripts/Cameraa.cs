using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraa : MonoBehaviour
{
    public Transform player; // Takip edilecek oyuncu karakteri
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Kamera ve oyuncu arasýndaki mesafe ve yükseklik farký
    public float rotationSpeed = 100f; // Dönüþ hýzý

    void Start()
    {
        // Kamera üst nesnesini atama
        transform.parent = player;
    }
    void Update()
    {
        // Input verilerini al
        float horizontalInput = Input.GetAxis("Horizontal");

        // Kameranýn ebeveyn nesnesini döndür
        transform.parent.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
    }
    void LateUpdate()
    {
        // Kameranýn oyuncunun pozisyonunu takip etmesi
        transform.position = player.position + offset;
    }
    
}
