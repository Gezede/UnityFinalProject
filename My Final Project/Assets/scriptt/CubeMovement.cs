using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 4f; // Normal hareket h�z�
    public float sprintSpeed = 8f; // Ko�ma h�z�

    void Update()
    {
        // Shift tu�una bas�l�ysa sprintSpeed'i kullan, de�ilse moveSpeed'i kullan
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;

        // Input verilerini al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Hareket et
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * currentSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}

