using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DX_Game : MonoBehaviour {

    

    //bool enemiesDetected;
    bool hasPlayed;
    
	// Use this for initialization
	void Start ()
    {
        //enemiesDetected = false;
        hasPlayed = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (ScoreManager.score >= 50 && !hasPlayed)
        {
            Invoke("DX_EnemiesDetected", 1f);
        }
        else if (ScoreManager.score >= 50 && hasPlayed)
        {
            CancelInvoke("DX_EnemiesDetected");
        }

    }

    void DX_EnemiesDetected()
    {
//********        AkSoundEngine.PostEvent("DX_DetectEnemy", gameObject);
        hasPlayed = true;
    }
}
