using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningCutScene02 : MonoBehaviour
{

    public float initDelay = 2f;

    public Text subText;

    private int hasPlayed = 0;
    

    // Use this for initialization
    void Start()
    {
        StartCoroutine(PlayDialogue());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator PlayDialogue()
    {
        yield return new WaitForSecondsRealtime(initDelay);

        if (hasPlayed == 0)
        {
            Line01();
            yield return new WaitForSecondsRealtime(initDelay);
        }

        if (hasPlayed == 1)
        {
            Line02();
            yield return new WaitForSecondsRealtime(initDelay);
        }

        if (hasPlayed == 2)
        {
            Line03();
            yield return new WaitForSecondsRealtime(initDelay);
        }

        if (hasPlayed == 3)
        {
            Line04();
            yield return new WaitForSecondsRealtime(initDelay);
        }


    }

    void Line01()
    {
//********        AkSoundEngine.PostEvent("DX_OpSc_01", gameObject);
        subText.text = "Greetings Captain!";
    }

    void Line02()
    {
//********        AkSoundEngine.PostEvent("DX_OpSc_02", gameObject);
        subText.text = "This is your ship, Odysseus speaking.";
    }

    void Line03()
    {
//********        AkSoundEngine.PostEvent("DX_OpSc_03", gameObject);
        subText.text = "I do apologise for waking you, but we are approaching our destination.";
    }

    void Line04()
    {
//********        AkSoundEngine.PostEvent("DX_OpSc_04", gameObject);
        subText.text = "Ready to initiate manual piloting controls on your command!";
    }
}
