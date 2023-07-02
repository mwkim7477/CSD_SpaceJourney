using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverAudio : MonoBehaviour, IPointerEnterHandler {

	public FMODUnity.StudioEventEmitter hoverMenuAudio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
		//********        AkSoundEngine.PostEvent("SFX_UIHover_play", gameObject);
		hoverMenuAudio.Play();
    }
}
