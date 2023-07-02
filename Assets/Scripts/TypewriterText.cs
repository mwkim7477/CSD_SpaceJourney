using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class TypewriterText : MonoBehaviour {

    // Attach to UI Text Component (with full text already there)

    public Text text;
    public bool playOnAwake = true;
    public float delayToStart;
    public float delayBetweenChars = 0.125f;
    public float delayAfterPunctuation = 0.5f;

    private string story;
    private float originDelayBetweenChars;
    private bool lastCharPunctuation = false;
    private char charComma;
    private char charPeriod;

    public Text skipText;

    public FMODUnity.StudioEventEmitter typeWriterAudio;

    void Awake()
    {
        text = GetComponent<Text>();
        originDelayBetweenChars = delayBetweenChars;

        charComma = Convert.ToChar(44);
        charPeriod = Convert.ToChar(46);

        if (playOnAwake)
        {
            ChangeText(text.text, delayToStart);
        }

    }

    // Update text and start typewriter effect
    public void ChangeText(string textContent, float delayBetweenChars = 0f)
    {
        StopCoroutine(PlayText()); //stop coroutine if exist
        story = textContent;
        text.text = ""; //clean text
        Invoke("Start_PlayText", delayBetweenChars); //Invoke effect
    }

    void Start_PlayText()
    {
        StartCoroutine(PlayText());
//********        AkSoundEngine.PostEvent("SFX_UIAmbData_play", gameObject);
    }

    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            delayBetweenChars = originDelayBetweenChars;

            if (lastCharPunctuation) //If previous character was a comma/period, pause typing
            {
                yield return new WaitForSecondsRealtime(delayBetweenChars = delayAfterPunctuation);
                lastCharPunctuation = false;
            }

            if (c == charComma || c == charPeriod)
            {
                lastCharPunctuation = true;
            }

            text.text += c;
            //********            AkSoundEngine.PostEvent("SFX_UITypeText_play", gameObject);
            typeWriterAudio.Play();
            yield return new WaitForSecondsRealtime(delayBetweenChars);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Skip();
        }

    }

    void Skip()
    {
        gameObject.SetActive(false);
        skipText.gameObject.SetActive(true);
//********        AkSoundEngine.PostEvent("SFX_UIResume_play", gameObject);
    }
}
