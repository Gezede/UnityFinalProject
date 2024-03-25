using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oyuncu : MonoBehaviour
{
    public Animator animasyon;
    public GameObject altin_efekti;
    public GameObject gameOverPAnel;

    public Text puan_txt;
    public Text CollectCoin_txt;

    public Transform road1;
    public Transform road2;

    public float itmeGucu = 10f;
    public bool dengesiniKoruyor = true;

    public Rigidbody rig1;
    bool sag = true;
    int puan = 0;
    int CollectCoin = 0;

    public bool miknatis_alindi = false;

    public AudioSource ses_dosyasi;
    public AudioSource kosma_sesi_dosyasi;
    public AudioClip altin_temas_sesi;
    private float roadLength = 49.6f; // Yolun uzunlu�u
    private float spawnOffset = 2.0f; // Yolun spawn edilece�i mesafe

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "oyuncu")
        {
            GameOver(); // Oyunu bitirme fonksiyonunu �a��r
            Destroy(gameObject); // Engeli yok et
        }
        if (other.gameObject.name == "End1")
        {
            road2.position = new Vector3(road1.position.x, road1.position.y, road1.position.z + roadLength);
        }
        if (other.gameObject.name == "End2")
        {
            road1.position = new Vector3(road2.position.x, road2.position.y, road2.position.z + roadLength);
        }
        if (other.gameObject.tag=="engel")
        {
            ses_dosyasi.PlayOneShot(altin_temas_sesi);
            GameObject yeni_alt�n_efekti = Instantiate(altin_efekti, other.gameObject.transform.position, Quaternion.identity);
            Destroy(yeni_alt�n_efekti, 0.5f);

            Destroy(other.gameObject);

            CollectCoin++;
            puan += 5;

            puan_txt.text = puan.ToString("0000");
            CollectCoin_txt.text = CollectCoin.ToString();
        }

        if (other.gameObject.tag == "miknatis")
        {
            GameObject[] tum_miknatislar = GameObject.FindGameObjectsWithTag("miknatis");
            
            foreach(GameObject miknatis in tum_miknatislar)
            {
                Destroy(miknatis);
            }
            miknatis_alindi = true;
            Invoke("miknatisi_resetle", 10.0f);
        }
    }

    void miknatis_resetle()
    {
        miknatis_alindi = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        kosma_sesi_dosyasi.enabled = true;
        if (collision.gameObject.CompareTag("engel") || collision.gameObject.CompareTag("car"))
        {
            if (dengesiniKoruyor)
            {
                // Karakterin dengesini korumas� isteniyorsa, geriye do�ru itme uygula
                Vector3 itmeYonu = (transform.position - collision.contacts[0].point).normalized;
                rig1.AddForce(itmeYonu * itmeGucu, ForceMode.Impulse);
            }
            else
            {
                // Karakterin dengesini korumas� istenmiyorsa, kinematik olmad���n� ve d��mesini sa�lay�n
                rig1.isKinematic = false;
            }
        }
    }
    void GameOver()
    {
        // Oyunu bitirme i�lemleri buraya gelecek
        Debug.Log("Oyun bitti!"); // Sadece bir �rnek, ger�ek oyunu bitirme i�lemleri buraya eklenecek

        // Karakterin d��mesini �nlemek i�in Rigidbody'yi kinematik yap
        rig1.isKinematic = true;

        // Oyun bitti�inde di�er i�lemleri yapmak i�in gereken kodu buraya ekleyebilirsiniz
    }
    private void OnCollisionExit(Collision collision)
    {
        kosma_sesi_dosyasi.enabled = false;
    }
    private void Update()
    {
        hareket();

        // Sonsuz yol olu�turmak i�in yolunun pozisyonunu g�ncelle
        if (transform.position.z > road1.position.z + roadLength - spawnOffset)
        {
            road1.position += new Vector3(0, 0, roadLength * 2);
        }
        if (transform.position.z > road2.position.z + roadLength - spawnOffset)
        {
            road2.position += new Vector3(0, 0, roadLength * 2);
        }
    }
    void hareket()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            animasyon.SetBool("zipla", true);
            rig1.velocity=Vector3.up*300.0f * Time.deltaTime;
            Invoke("ziplama_iptal", 0.5f);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            sag = true;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sag = false;

        }
        if(sag)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(2.9f, transform.position.y, transform.position.z), Time.deltaTime * 3.0f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-4.4f, transform.position.y, transform.position.z), Time.deltaTime * 3.0f);
        }

        transform.Translate(0, 0, 5 * Time.deltaTime);

    }
    void ziplama_iptal()

    {
        animasyon.SetBool("zipla", false);
    }
}
