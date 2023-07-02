using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Engine_Audio : MonoBehaviour {
    
    	Engine m_Engine;
    
	public bool enginego;
    	private bool engineAudioPlaying;
    	public float thrust;
    	public float playerTurnRate;
    	private bool thrustLoopAudioPlaying;
        public StudioEventEmitter engineStart;
    public float playerTurnRateH;
    public float playerTurnRateV;
    public float interiorEngine;
    public float reverb;
    public FMODUnity.StudioEventEmitter reverbSnapshot;
    public FMODUnity.StudioEventEmitter noReverbSnapshot;

    // Use this for initialization
    void Start ()
	{
        	m_Engine = GetComponent<Engine>();
        	enginego = false;
        	engineAudioPlaying = false;
        	thrustLoopAudioPlaying = false;
        noReverbSnapshot.Play();

        	CalculateThrust();
        	SetThrustRTPC();

        	CalculatePlayerTurnRate();
        	SetPlayerRotRTPC();
    	}

    // Update is called once per frame
    void Update()
    {
            CalculateThrust();
        	SetThrustRTPC();
        	CalculatePlayerTurnRate();
        	SetPlayerRotRTPC();

        	EngineRunning();
        CameraSwitch();
        	Thrusting();
    }

    void CameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.C) && interiorEngine == 0)
        {
            interiorEngine = 1;
            engineStart.SetParameter("Interior Engine", interiorEngine);
        }
        else if (Input.GetKeyDown(KeyCode.C) && interiorEngine == 1)
        {
            interiorEngine = 0;
            engineStart.SetParameter("Interior Engine", interiorEngine);
        }
    }

    	void EngineRunning()
    	{
        	if (thrust <= 0)
        	{
            		enginego = false;
        	}
   
        	if (thrust > 0)
        	{
            		enginego = true;
        	}

        	if (enginego == true && engineAudioPlaying == false)
        	{
            		PlayEngineAudio();
        	}
    }

        public void StopEngineAudio()
        {
            engineAudioPlaying = false;
            engineStart.Stop();
        }

    	public void PlayEngineAudio()
    	{
            engineAudioPlaying = true;
            // called when  the ship's engine starts
            engineStart.Play();
    	}

    	void SetThrustRTPC()
    	{
            // use this to utilise the 'thrust' parameter
            engineStart.SetParameter("Thrust", thrust);
        }

    	void SetPlayerRotRTPC()
    	{
            // use this to utilise the 'playerTurnRate' parameter
            engineStart.SetParameter("TurnH", playerTurnRateH);
            engineStart.SetParameter("TurnV", playerTurnRateV);
        }

    	void CalculateThrust()
    	{
        	thrust = m_Engine.enginePowerFloat;
    	}

    	void CalculatePlayerTurnRate()
    	{
            //playerTurnRate = Mathf.Clamp(((Input.mousePosition.x / Screen.width) * 100f) + ((Input.mousePosition.y / Screen.width) * 100f), 0f, 100f);
            playerTurnRateH = Mathf.Clamp(((Input.mousePosition.x / Screen.width) * 100f), 0f, 100f);
            playerTurnRateV = Mathf.Clamp(((Input.mousePosition.y / Screen.height) * 100f), 0f, 100f);
        }

    	void PlayThrustStartAudio()
    	{
			// called when the thrust is activated

    	}

    	void PlayThrustLoopAudio()
    	{
        	thrustLoopAudioPlaying = true;
			// called while thrust is active
    	}

    	void StopThrustLoopAudio()
    	{
        	thrustLoopAudioPlaying = false;
			// called when thrust is inactive
    	}

    	void PlayThrustEndAudio()
    	{
			// called when thrust stops
    	}

    	void Thrusting()
    	{
        	if (Input.GetKeyDown("left shift"))
		{
            		Invoke("PlayThrustStartAudio", 0f);
        	}

        	if (Input.GetKey("left shift") && thrustLoopAudioPlaying == false)
        	{
            		Invoke("PlayThrustLoopAudio", 0f);
        	}
        
        	if (Input.GetKeyUp("left shift"))
        	{
            		Invoke("StopThrustLoopAudio", 0f);
            		Invoke("PlayThrustEndAudio", 0f);
        	} 
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
            reverbSnapshot.Stop();
            noReverbSnapshot.Play();
        }
    }
}
