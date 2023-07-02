using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOpenMenuAudio : MonoBehaviour {

    public FMODUnity.StudioEventEmitter openMenuAudio;

    public void PlayOpenMenuAudio()
    {
        //********        AkSoundEngine.PostEvent("SFX_UIClick_play", gameObject);
        openMenuAudio.Play();
    }
}
