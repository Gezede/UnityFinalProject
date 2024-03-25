using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRunner : MonoBehaviour
{
    public Transform player; // Oyuncu karakteri
    public Transform road1, road2; // Yol parçalarý
    public float roadPieceLength = 10f; // Yol parçalarýnýn uzunluðu

    private Transform currentRoad; // Þu anki yol parçasý

    void Start()
    {
        currentRoad = road2; // Ýlk olarak road2'yi kullanýyoruz
    }

    void Update()
    {
        // Karakteri ileriye doðru hareket ettir
        player.Translate(Vector3.forward * Time.deltaTime * 5f);

        // Yolu kontrol et
        CheckRoad();
    }

    void CheckRoad()
    {
        // Eðer oyuncu road1'in sonuna ulaþtýysa, road2'nin arkasýna getir
        if (player.position.z > road1.position.z + roadPieceLength)
        {
            road1.position = new Vector3(road1.position.x, road1.position.y, road2.position.z + roadPieceLength);
            currentRoad = road1;
        }
        // Eðer oyuncu road2'nin sonuna ulaþtýysa, road1'in arkasýna getir
        else if (player.position.z > road2.position.z + roadPieceLength)
        {
            road2.position = new Vector3(road2.position.x, road2.position.y, road1.position.z + roadPieceLength);
            currentRoad = road2;
        }
    }
}
