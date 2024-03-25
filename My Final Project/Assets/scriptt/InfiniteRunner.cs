using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRunner : MonoBehaviour
{
    public Transform player; // Oyuncu karakteri
    public Transform road1, road2; // Yol par�alar�
    public float roadPieceLength = 10f; // Yol par�alar�n�n uzunlu�u

    private Transform currentRoad; // �u anki yol par�as�

    void Start()
    {
        currentRoad = road2; // �lk olarak road2'yi kullan�yoruz
    }

    void Update()
    {
        // Karakteri ileriye do�ru hareket ettir
        player.Translate(Vector3.forward * Time.deltaTime * 5f);

        // Yolu kontrol et
        CheckRoad();
    }

    void CheckRoad()
    {
        // E�er oyuncu road1'in sonuna ula�t�ysa, road2'nin arkas�na getir
        if (player.position.z > road1.position.z + roadPieceLength)
        {
            road1.position = new Vector3(road1.position.x, road1.position.y, road2.position.z + roadPieceLength);
            currentRoad = road1;
        }
        // E�er oyuncu road2'nin sonuna ula�t�ysa, road1'in arkas�na getir
        else if (player.position.z > road2.position.z + roadPieceLength)
        {
            road2.position = new Vector3(road2.position.x, road2.position.y, road1.position.z + roadPieceLength);
            currentRoad = road2;
        }
    }
}
