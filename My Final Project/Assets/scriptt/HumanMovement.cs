using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    public Transform[] waypoints; // Yol noktalarý
    public float speed = 3f; // Hareket hýzý
    private int currentWaypointIndex = 0; // Mevcut hedef yol noktasý
    private Vector3 movementDirection; // Hareket yönü

    void Update()
    {
        if (waypoints.Length == 0)
            return;

        // Hedef noktaya doðru ilerleme
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        // Hedef noktaya ulaþýldýðýnda bir sonraki hedefi ayarlama
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // Karakter bir engelle çarparsa yönünü deðiþtir
        if (collision.gameObject.CompareTag("Car") || collision.gameObject.CompareTag("Barrier"))
        {
            // Yönü tersine çevir
            transform.Rotate(0f, 180f, 0f);
            movementDirection = transform.forward;
            // Engel objesine göre yeni bir yön belirle
            Vector3 newDirection = Vector3.Reflect(movementDirection, collision.contacts[0].normal);
            movementDirection = newDirection.normalized;
        }
    }
}
