using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSystem : MonoBehaviour 
{

	public float coolDown01 = 0f;
	public float fireRate01 = 0f;
	public float coolDown02 = 0f;
	public float fireRate02 = 0f;

	// Check to see if player is firing weapon
    	public bool isFiring01 = false;
	public bool isFiring02 = false;

    	// Firing point transforms for launching projectiles
    	public Transform leftFiringPoint;
    	public Transform rightFiringPoint;

    	// Projectile Object
    	public GameObject laserPrefab01;
	public GameObject laserPrefab02;

    	// Use this for initialization
    	void Start ()
	{
	        isFiring01 = false;
		isFiring02 = false;
 	}
	
	// Update is called once per frame
	void Update ()
	{
        	CheckInput();
        	coolDown01 -= Time.deltaTime;
        	if (coolDown01 <= 0)
        	{
            		coolDown01 = 0;
        	}
		coolDown02 -= Time.deltaTime;
		if (coolDown02 <= 0)
		{
			coolDown02 = 0;
		}

        	// Track mouse position
        	Vector3 mousePositionVector3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        	mousePositionVector3 = Camera.main.ScreenToWorldPoint(mousePositionVector3);

	//        Vector3 targetDir = mousePositionVector3 - transform.position;

	        if (isFiring01 == true)
        	{
            		Fire01();
        	}
		if (isFiring02 == true)
		{
			Fire02();
		}
	}

    	void CheckInput()
	{
        	if (Input.GetMouseButtonDown(0))
        	{
            		isFiring01 = true;
        	}
		else if (Input.GetMouseButtonDown(1))
		{
			isFiring02 = true;
		}
        	else
        	{
            		isFiring01 = false;
			isFiring02 = false;
        	}
	}

    	void Fire01()
    	{
        	// Check coolDown
        	if (coolDown01 > 0)
        	{
            		return; // Do Not Fire!
        	}
        	// Fire Weapon 01!
        	GameObject.Instantiate(laserPrefab01, leftFiringPoint.position, leftFiringPoint.rotation);
        	GameObject.Instantiate(laserPrefab01, rightFiringPoint.position, rightFiringPoint.rotation);

        	coolDown01 = fireRate01;
    	}

	void Fire02()
	{
		// Check coolDown
		if (coolDown02 > 0)
		{
			return; // Do Not Fire!
		}
		// Fire Weapon 02!
		GameObject.Instantiate(laserPrefab02, leftFiringPoint.position, leftFiringPoint.rotation);
		GameObject.Instantiate(laserPrefab02, rightFiringPoint.position, rightFiringPoint.rotation);

		coolDown02 = fireRate02;
	}
}
