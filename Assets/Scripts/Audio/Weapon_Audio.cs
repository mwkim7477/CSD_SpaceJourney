using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Audio : MonoBehaviour 
{
    public FMODUnity.StudioEventEmitter laserRedShoot;
    public FMODUnity.StudioEventEmitter laserGreenShoot;
    public FMODUnity.StudioEventEmitter reverbSnapshot;
    public FMODUnity.StudioEventEmitter noReverbSnapshot;

    // Use this for initialization
    void Start () 
	{
        noReverbSnapshot.Play();  
    }
	
	// Update is called once per frame
	void Update ()
        {
        	if (Input.GetMouseButtonDown(0))
        	{
            	FireWeapon01();
        	}
			if (Input.GetMouseButtonDown(1))
			{
				FireWeapon02();
			}
    	}
		
    // Fire Weapon 01
    void FireWeapon01()
    {
        //use this to trigger anything you want to happen when weapon 1 is fired
        laserRedShoot.Play();
    }

    // Fire Weapon 02
    void FireWeapon02()
    {
        //use this to trigger anything you want to happen when weapon 2 is fired
        laserGreenShoot.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "PickUp")
        {
            noReverbSnapshot.Stop();
            reverbSnapshot.Play();
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag != "PickUp")
        {
            noReverbSnapshot.Play();
            reverbSnapshot.Stop();
        }
    }
}
