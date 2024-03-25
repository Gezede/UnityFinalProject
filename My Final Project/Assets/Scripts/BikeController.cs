using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    public WheelCollider OnSol;
    public WheelCollider OnSag;
    public WheelCollider ArkaSol;
    public WheelCollider ArkaSag;

    public GameObject Wheel_BL;
    public GameObject Wheel_FL;
    public GameObject Wheel_BR;
    public GameObject Wheel_FR;

    public float maxMotorGucu;
    public float maxDonusAcisi;
    public float motor;
    public float frenGucu;

    public float hiz_ayar;
    public bool Kontak;
    public float speed;

    private Rigidbody _rb;

    public GameObject imlec;

    private void Update()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void gostergeKontrol()
    {
        float arac_hiz = Mathf.Abs(speed);
        RectTransform _gosterge = imlec.GetComponent<RectTransform>();
        _gosterge.eulerAngles = new Vector3(0, 0, -arac_hiz);
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E)) Kontak = !Kontak;
        if (Kontak)
        {
            speed = transform.InverseTransformDirection(_rb.velocity).z * hiz_ayar;
            motor = maxMotorGucu * Input.GetAxis("Vertical");
            float donus = maxDonusAcisi * Input.GetAxis("Horizontal");
            
            float elfrenTorku = frenGucu * Mathf.Abs(Input.GetAxis("Jump"));

            OnSag.steerAngle = OnSol.steerAngle = donus;
            ArkaSol.motorTorque = ArkaSag.motorTorque = motor;

            if(elfrenTorku<0.05)
            {
                ArkaSag.motorTorque = motor;
                ArkaSol.motorTorque = motor;
                ArkaSag.brakeTorque = 0;
                ArkaSol.brakeTorque = 0;
                OnSag.brakeTorque = 0;
                OnSol.brakeTorque = 0;
            }
            else
            {
                ArkaSag.brakeTorque = elfrenTorku;
                ArkaSol.brakeTorque = elfrenTorku;
                OnSag.brakeTorque = elfrenTorku;
                OnSol.brakeTorque = elfrenTorku;
            }

           
        }
        SanalTeker();
    }
    void SanalTeker()
    {
        Quaternion rot;
        Vector3 pos;
        OnSol.GetWorldPose(out pos, out rot);
        Wheel_FL.transform.position = pos;
        Wheel_FL.transform.rotation = rot;
        OnSag.GetWorldPose(out pos, out rot);
        Wheel_FR.transform.position = pos;
        Wheel_FR.transform.rotation = rot;
        ArkaSol.GetWorldPose(out pos, out rot);
        Wheel_BL.transform.position = pos;
        Wheel_BL.transform.rotation = rot;
        ArkaSag.GetWorldPose(out pos, out rot);
        Wheel_BR.transform.position = pos;
        Wheel_BR.transform.rotation = rot;

    }
}