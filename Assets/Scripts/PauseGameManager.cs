using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseGameManager : MonoBehaviour {

    bool isPaused;

    public GameObject pauseMenu;
    public GameObject player;
    public Button resumeGameButton;
    private Engine_Audio engineScript;
    
    

	// Use this for initialization
	void Start ()
    {
        isPaused = false;
        engineScript = player.GetComponent<Engine_Audio>();
        pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        PauseGameControl();
        SetTimeScale();
	}

    void PauseGameControl()
    {
        if (Input.GetKeyDown("escape") && Time.timeScale == 1f)
        {
            PauseGame();
            engineScript.StopEngineAudio();
        }
        else if (Input.GetKeyDown("escape") && Time.timeScale == 0f)
        {
            ResumeGame();
            engineScript.PlayEngineAudio();
        }

        
    }

    void SetTimeScale()
    {
        if (isPaused == false)
        {
            Time.timeScale = 1f;
        }
        else if (isPaused == true)
        {
            Time.timeScale = 0f;
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
//********        AkSoundEngine.PostEvent("SFX_UIPause_control", null);
//********        AkSoundEngine.PostEvent("SFX_UIPause_play", gameObject);
        player.SetActive(false);
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        player.SetActive(true);
//********        AkSoundEngine.PostEvent("SFX_UIResume_control", null);
//********        AkSoundEngine.PostEvent("SFX_UIResume_play", gameObject);
        isPaused = false;
    }
}
