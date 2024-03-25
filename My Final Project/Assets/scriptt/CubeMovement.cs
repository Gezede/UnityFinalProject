using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 4f; // Normal hareket hýzý
    public float sprintSpeed = 8f; // Koþma hýzý

    void Update()
    {
        // Shift tuþuna basýlýysa sprintSpeed'i kullan, deðilse moveSpeed'i kullan
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;

        // Input verilerini al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Hareket et
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * currentSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}

