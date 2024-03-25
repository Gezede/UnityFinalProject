using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator; // Animator bile�eni referans�
    public float moveSpeed = 5f; // Oyuncunun hareket h�z�
    public float jumpForce = 8f; // Z�plama kuvveti
    public float minX = -4f; // Minimum x koordinat�
    public float maxX = 2.9f; // Maksimum x koordinat�

    private bool isGrounded; // Karakterin yere temas edip etmedi�ini belirten bir bayrak

    void Start()
    {
        // Animator bile�enini al
        animator = GetComponent<Animator>();
        Time.timeScale = 1;
    }

    void Update()
    {
        // Klavye giri�lerini al
        float horizontalInput = Input.GetAxis("Horizontal"); // Sa�/Sol

        // Hareket vekt�r�n� olu�tur
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;

        // Oyuncunun yeni konumunu hesapla
        Vector3 newPosition = transform.position + movement;

        // Konumu s�n�rla
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Yerde olup olmad���n� kontrol et
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }


        // Oyuncuyu yeni konuma ta��
        transform.position = newPosition;


        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

    }

    void Jump()
    {
        // "Jump" parametresini true yaparak z�plama animasyonunu ba�lat
        animator.SetBool("Jump", true);
        // Z�plama kuvveti uygula
        GetComponent<Rigidbody>().velocity = new Vector3(0f, jumpForce, 0f);

        // Yerde olmad���n� belirt
        isGrounded = false;
    }

    // Animasyonun sonunda �a�r�lacak bir metod
    public void OnJumpAnimationEnd()
    {
        animator.SetBool("Jump", false);
        isGrounded = true; // Z�plama animasyonu tamamland���nda karakterin tekrar yerde oldu�unu belirtin
    }

    void OnCollisionEnter(Collision collision)
    {
        
        
            if (collision.gameObject.CompareTag("engel"))
            {
                Debug.Log("Engelle �arp��ma!"); // �stedi�iniz i�lemleri yapabilirsiniz (�rne�in, oyunu durdurma veya arac� yeniden konumland�rma)
            }

        
        // Yere temas edildi�inde
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
