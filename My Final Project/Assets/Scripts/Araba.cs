using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Araba : MonoBehaviour
{
    float hiz = 5;
    private void Update()
    {
        transform.Translate(0, 0,- hiz * Time.deltaTime);
    }
    // Engellerin ters y�nde hareket etmesini sa�layacak fonksiyon

}
