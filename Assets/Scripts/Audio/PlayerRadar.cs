using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRadar : MonoBehaviour {

    public static bool radarActive;
    

	// Use this for initialization
	void Start ()
    {
        radarActive = false;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.R) && radarActive == false)
        {
            
            StartRadar();
        }

        else if (Input.GetKeyDown(KeyCode.R) && radarActive == true)
        {
            
            StopRadar();
        }
    }

    void StartRadar()
    {
//********        AkSoundEngine.PostEvent("SFX_PRadarStart_play", gameObject);
        radarActive = true;

    }

    void StopRadar()
    {
//********        AkSoundEngine.PostEvent("SFX_PRadarEnd_play", gameObject);
        radarActive = false;

    }
}
