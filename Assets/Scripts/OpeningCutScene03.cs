using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningCutScene03 : MonoBehaviour
{

    public float initDelay = 12f;

    public Text subText;
    public Text readyText;

    public bool hasPlayed = false;


    // Use this for initialization
    void Start()
    {
        hasPlayed = false;
        StartCoroutine(PlayDialogue());
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPlayed == true)
        {
            readyText.gameObject.SetActive(true);
        }
    }

    IEnumerator PlayDialogue()
    {
        yield return new WaitForSecondsRealtime(8);
        yield return Line01();
        yield return Line02();
        yield return Line03();
        yield return Line04();
    }

    private IEnumerator Line01()
    {
//********        AkSoundEngine.PostEvent("DX_OpSc_01_play", gameObject);
        subText.text = "Greetings Captain!";
        yield return new WaitForSecondsRealtime(2);
    }

    private IEnumerator Line02()
    {
//********        AkSoundEngine.PostEvent("DX_OpSc_02_play", gameObject);
        subText.text = "This is your ship, Odysseus speaking.";
        yield return new WaitForSecondsRealtime(4);
    }

    private IEnumerator Line03()
    {
//********        AkSoundEngine.PostEvent("DX_OpSc_03_play", gameObject);
        subText.text = "I do apologise for waking you, but we are approaching our destination.";
        yield return new WaitForSecondsRealtime(5);
    }

    private IEnumerator Line04()
    {
//********        AkSoundEngine.PostEvent("DX_OpSc_04_play", gameObject);
        subText.text = "Ready to initiate manual piloting controls on your command!";
        hasPlayed = true;
        Debug.Log("ready");
        yield return new WaitForSecondsRealtime(2);
        
    }
}

