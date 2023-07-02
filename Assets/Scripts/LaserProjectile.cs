using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour {

    public float speed = 2f; // speed projectile travels in world space
    public int damage = 25; // damage caused when projectile hits other objects
    private Transform thisTransform; // cached transform for this projectile
    public Transform laserHitFXPrefab;


	// Use this for initialization
	void Start () {

        thisTransform = transform;
		
	}
	
	// Update is called once per frame
	void Update () {

        thisTransform.position += Time.deltaTime * speed * thisTransform.forward;
		
	}

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(laserHitFXPrefab, pos, rot);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Prop")
        {
            collision.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(laserHitFXPrefab, pos, rot);
            Destroy(gameObject);
        }
    }
}
