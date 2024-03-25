using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    public Transform[] waypoints; // Yol noktalar�
    public float speed = 3f; // Hareket h�z�
    private int currentWaypointIndex = 0; // Mevcut hedef yol noktas�
    private Vector3 movementDirection; // Hareket y�n�

    void Update()
    {
        if (waypoints.Length == 0)
            return;

        // Hedef noktaya do�ru ilerleme
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        // Hedef noktaya ula��ld���nda bir sonraki hedefi ayarlama
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // Karakter bir engelle �arparsa y�n�n� de�i�tir
        if (collision.gameObject.CompareTag("Car") || collision.gameObject.CompareTag("Barrier"))
        {
            // Y�n� tersine �evir
            transform.Rotate(0f, 180f, 0f);
            movementDirection = transform.forward;
            // Engel objesine g�re yeni bir y�n belirle
            Vector3 newDirection = Vector3.Reflect(movementDirection, collision.contacts[0].normal);
            movementDirection = newDirection.normalized;
        }
    }
}
