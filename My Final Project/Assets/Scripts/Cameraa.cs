using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraa : MonoBehaviour
{
    public Transform player; // Takip edilecek oyuncu karakteri
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Kamera ve oyuncu aras�ndaki mesafe ve y�kseklik fark�
    public float rotationSpeed = 100f; // D�n�� h�z�

    void Start()
    {
        // Kamera �st nesnesini atama
        transform.parent = player;
    }
    void Update()
    {
        // Input verilerini al
        float horizontalInput = Input.GetAxis("Horizontal");

        // Kameran�n ebeveyn nesnesini d�nd�r
        transform.parent.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
    }
    void LateUpdate()
    {
        // Kameran�n oyuncunun pozisyonunu takip etmesi
        transform.position = player.position + offset;
    }
    
}
