using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VR_Inputs : MonoBehaviour
{
    public AudioSource Gunshot;
    public Animator Gun_ani;
    public GameObject Bullet, MuzzlePoint, muzzleflash;

    void Update()
    {
        Gun_ani.SetFloat("Trigger", SteamVR_Actions.default_Squeeze.GetAxis(SteamVR_Input_Sources.RightHand));
        if (SteamVR_Actions.default_GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            Gun_ani.SetTrigger("Fire");
            Gunshot.Play();
            var bulllet = Instantiate(Bullet, MuzzlePoint.transform.position, MuzzlePoint.transform.rotation);
            var flash = Instantiate(muzzleflash, MuzzlePoint.transform.position, MuzzlePoint.transform.rotation);
            bulllet.GetComponent<Rigidbody>().AddForce(MuzzlePoint.transform.forward * 1000);
            Destroy(flash.gameObject, 0.5f);
            Destroy(bulllet.gameObject, 3.0f);
        }
    }
}