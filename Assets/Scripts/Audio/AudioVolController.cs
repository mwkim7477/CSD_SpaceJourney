using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioVolController : MonoBehaviour {

    public Slider masterVolSlider;
    public Slider sfxVolSlider;
    public Slider musicVolSlider;

    public float masterVolFloat;
    public float sfxVolFloat;
    public float musicVolFloat;

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start ()
    {
        
        masterVolSlider.value = GlobalVolControl.instance.masterVol;
        sfxVolSlider.value = GlobalVolControl.instance.sfxVol;
        musicVolSlider.value = GlobalVolControl.instance.musicVol;

        masterVolFloat = masterVolSlider.value;
        sfxVolFloat = sfxVolSlider.value;
        musicVolFloat = musicVolSlider.value;

        VolControl();
        SaveVolData();
	}
	
	// Update is called once per frame
	void Update ()
    {
        masterVolFloat = masterVolSlider.value;
        sfxVolFloat = sfxVolSlider.value;
        musicVolFloat = musicVolSlider.value;
        
        VolControl();
        SaveVolData();
	}

    void VolControl()
    {
//********        AkSoundEngine.SetRTPCValue("MST_Vol_param", masterVolFloat);
//********        AkSoundEngine.SetRTPCValue("SFX_Vol_param", sfxVolFloat);
//********        AkSoundEngine.SetRTPCValue("MX_Vol_param", musicVolFloat);
    }

    public void SaveVolData()
    {
        GlobalVolControl.instance.masterVol = masterVolFloat;
        GlobalVolControl.instance.sfxVol = sfxVolFloat;
        GlobalVolControl.instance.musicVol = musicVolFloat;
    }
}
