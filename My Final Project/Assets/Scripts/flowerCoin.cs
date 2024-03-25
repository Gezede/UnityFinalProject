using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerCoin : MonoBehaviour
{
    Oyuncu cocuk;
    Transform temas_edilen_kup;

    float mesafe;

    private void Start()
    {
        cocuk = GameObject.Find("cocuk").GetComponent<Oyuncu>();
        temas_edilen_kup = GameObject.Find("cocuk/temas_edilen_kup").transform;
    }

    private void Update()
    {
        if(cocuk.miknatis_alindi==true)
        {
            mesafe = Vector3.Distance(transform.position, temas_edilen_kup.position);
         if(mesafe<=10)
            {
                transform.position = Vector3.MoveTowards(transform.position, temas_edilen_kup.position, Time.deltaTime * 10.0f);
            }
        }
    }
}
