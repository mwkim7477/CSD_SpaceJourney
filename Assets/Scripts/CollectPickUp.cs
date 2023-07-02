using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectPickUp : MonoBehaviour {

    public int scoreValue = 10;
    public GameObject pickUpFX;
    public GameObject player;
    
    bool isPlaying;

    public float selfDestuctTime = 20f;

    private void Awake()
    {
        player = ReferenceManager.player;
    }

    // Use this for initialization
    void Start ()
    {
        isPlaying = false;
        player = ReferenceManager.player;
    }
	
	// Update is called once per frame
	void Update ()
    {
        selfDestuctTime -= Time.deltaTime;
        if (selfDestuctTime <= 0 && isPlaying == false)
        {
            Destroy(gameObject);
        }
        else if (selfDestuctTime <= 0 && isPlaying == true)
        {
            StopLocatorAudio();
            Destroy(gameObject);
        }

        if (PlayerRadar.radarActive == true && isPlaying == false)
        {
            StartLocatorAudio();
        }

        if (PlayerRadar.radarActive == false && isPlaying == true)
        {
            StopLocatorAudio();
        }
    }

    void StartLocatorAudio()
    {
//********        AkSoundEngine.PostEvent("SFX_PULocator_play", gameObject);

        isPlaying = true;
    }

    void StopLocatorAudio()
    {
//********        AkSoundEngine.PostEvent("SFX_PULocator_stop", gameObject);
        isPlaying = false;
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            ScoreManager.score += scoreValue;
            Instantiate(pickUpFX, transform.position, transform.rotation);
//********            AkSoundEngine.PostEvent("SFX_PUColl_play", player);
            StopLocatorAudio();
            Destroy(gameObject);
            
        }
    }
}
