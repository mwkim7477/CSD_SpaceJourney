using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICloseMenuAudio : MonoBehaviour {

    public FMODUnity.StudioEventEmitter closeMenuAudio;

    public void PlayCloseMenuAudio()
    {
        //********        AkSoundEngine.PostEvent("SFX_UIBack_play", gameObject);
        closeMenuAudio.Play();
    }
}
