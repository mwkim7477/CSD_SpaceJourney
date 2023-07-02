using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpSceneEngineAudio : MonoBehaviour {

    public float scaledTimeScale;
    

    // Use this for initialization
    void Start ()
    {
        CalculateScaledTimeScale();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        CalculateScaledTimeScale();
        SetTimeScaleRTPC();
	}

    void CalculateScaledTimeScale()
    {
        scaledTimeScale = Time.timeScale * 100;
    }

    void SetTimeScaleRTPC()
    {
//********        AkSoundEngine.SetRTPCValue("TimeScale", scaledTimeScale);
    }
}
