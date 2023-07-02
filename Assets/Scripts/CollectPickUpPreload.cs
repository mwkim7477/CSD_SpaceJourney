using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPickUpPreload : MonoBehaviour {

    public int scoreValue = 10;
    public GameObject pickUpFX;
    public GameObject player;
    public FMODUnity.StudioEventEmitter pickupSound;
    
    // Use this for initialization
    void Start()
    {
        
    }

       void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            // called when the player 'collects' this pickup
            pickupSound.Play();
            ScoreManager.score += scoreValue;
            Instantiate(pickUpFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
