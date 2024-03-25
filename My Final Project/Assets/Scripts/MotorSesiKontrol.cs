using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorSesiKontrol : MonoBehaviour
{
    public AudioClip start;
    public AudioClip Working;
    public AudioClip close;

    public float du_hiz;
    public float mi_pit;
    public float pi_hiz;

    private AudioSource _source;
    bool kontak;
    float hiz;

    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        kontak = GetComponent<BikeController>().Kontak;
        hiz = GetComponent<BikeController>().speed;

        if(!kontak && _source.clip==Working)
        {
            _source.clip = close;
            _source.Play();
        }
        if (kontak && ( _source.clip==close||_source.clip==null))
        {
            _source.clip = start;
            _source.Play();
            _source.pitch = 1;
        }
        if(kontak&&!_source.isPlaying)
        {
            _source.clip = Working;
            _source.Play();
        }
        if(_source.clip==Working)
        {
            _source.pitch = Mathf.Lerp(_source.pitch, mi_pit + Mathf.Abs(hiz) / du_hiz, pi_hiz);
        }
        
    }
}
