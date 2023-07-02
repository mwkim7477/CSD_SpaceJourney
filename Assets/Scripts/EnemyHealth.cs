using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float hitPoints = 100f;
    public float currentHitPoints;
    public GameObject destroyFX;

    SpawnManager spawnManager;
    MX_States mxStates;

	// Use this for initialization
	void Start () {
        currentHitPoints = hitPoints;
	}

    public void TakeDamage (float amt)
    {
        currentHitPoints -= amt;
        if (currentHitPoints <= 0)
        {
            currentHitPoints = 0;
            Die();
        }
    }

    void Die()
    {
        if (gameObject.tag == "Enemy")
        {
            Instantiate(destroyFX, transform.position, transform.rotation);
//********            AkSoundEngine.PostEvent("SFX_ExploLrg_play", gameObject);
//********            AkSoundEngine.PostTrigger("MX_KillEnemy", null);
            MX_States.enEngaged -= 1;

            Destroy(gameObject);
        }
    }

    // Damage on collision
    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Player")
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(destroyFX, pos, rot);
            Destroy(gameObject);
        }

        if (gameObject.tag == "Enemey")
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(destroyFX, pos, rot);
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
