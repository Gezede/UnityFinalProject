using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator; // Animator bileþeni referansý
    public float moveSpeed = 5f; // Oyuncunun hareket hýzý
    public float jumpForce = 8f; // Zýplama kuvveti
    public float minX = -4f; // Minimum x koordinatý
    public float maxX = 2.9f; // Maksimum x koordinatý

    private bool isGrounded; // Karakterin yere temas edip etmediðini belirten bir bayrak

    void Start()
    {
        // Animator bileþenini al
        animator = GetComponent<Animator>();
        Time.timeScale = 1;
    }

    void Update()
    {
        // Klavye giriþlerini al
        float horizontalInput = Input.GetAxis("Horizontal"); // Sað/Sol

        // Hareket vektörünü oluþtur
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;

        // Oyuncunun yeni konumunu hesapla
        Vector3 newPosition = transform.position + movement;

        // Konumu sýnýrla
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Yerde olup olmadýðýný kontrol et
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }


        // Oyuncuyu yeni konuma taþý
        transform.position = newPosition;


        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

    }

    void Jump()
    {
        // "Jump" parametresini true yaparak zýplama animasyonunu baþlat
        animator.SetBool("Jump", true);
        // Zýplama kuvveti uygula
        GetComponent<Rigidbody>().velocity = new Vector3(0f, jumpForce, 0f);

        // Yerde olmadýðýný belirt
        isGrounded = false;
    }

    // Animasyonun sonunda çaðrýlacak bir metod
    public void OnJumpAnimationEnd()
    {
        animator.SetBool("Jump", false);
        isGrounded = true; // Zýplama animasyonu tamamlandýðýnda karakterin tekrar yerde olduðunu belirtin
    }

    void OnCollisionEnter(Collision collision)
    {
        
        
            if (collision.gameObject.CompareTag("engel"))
            {
                Debug.Log("Engelle çarpýþma!"); // Ýstediðiniz iþlemleri yapabilirsiniz (örneðin, oyunu durdurma veya aracý yeniden konumlandýrma)
            }

        
        // Yere temas edildiðinde
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
