using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningCutScene : MonoBehaviour {

    public float initDelay = 2f;

    public Text subText;

    //private int hasPlayed = 0;


    // Use this for initialization
    void Start ()
    {
        //hasPlayed = 0;
        StartCoroutine(PlayDialogue());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator PlayDialogue()
    {
        yield return new WaitForSecondsRealtime(initDelay);
//********        yield return Line01(AkCallbackType.AK_EndOfEvent);
//********        yield return Line02(AkCallbackType.AK_EndOfEvent);
//********        yield return Line03(AkCallbackType.AK_EndOfEvent);
//********        yield return Line04(AkCallbackType.AK_EndOfEvent);
    }

/*    private IEnumerator Line01(AkCallbackType in_type01)
    {
        AkSoundEngine.PostEvent("DX_OpSc_01", gameObject, (uint) AkCallbackType.AK_EnableGetSourcePlayPosition | (uint) AkCallbackType.AK_EndOfEvent);
        subText.text = "Greetings Captain!";
        if (in_type01 == AkCallbackType.AK_EndOfEvent)
        {
            yield return new WaitForSecondsRealtime(initDelay);
            hasPlayed = hasPlayed + 1;
        }
        
    }
*/
 /*   private IEnumerator Line02(AkCallbackType in_type02)
    {
        AkSoundEngine.PostEvent("DX_OpSc_02", gameObject, (uint)AkCallbackType.AK_EnableGetSourcePlayPosition | (uint)AkCallbackType.AK_EndOfEvent);
        subText.text = "This is your ship, Odysseus speaking.";
        if (in_type02 == AkCallbackType.AK_EndOfEvent)
        {
            yield return new WaitForSecondsRealtime(initDelay);
            hasPlayed = hasPlayed + 1;
        }
    }
*/
 /*   private IEnumerator Line03(AkCallbackType in_type03)
    {
        AkSoundEngine.PostEvent("DX_OpSc_03", gameObject, (uint)AkCallbackType.AK_EnableGetSourcePlayPosition | (uint)AkCallbackType.AK_EndOfEvent);
        subText.text = "I do apologise for waking you, but we are approaching our destination.";
        if (in_type03 == AkCallbackType.AK_EndOfEvent)
        {
            yield return new WaitForSecondsRealtime(initDelay);
            hasPlayed = hasPlayed + 1;
        }
    }
*/
 /*   private IEnumerator Line04(AkCallbackType in_type04)
    {
        AkSoundEngine.PostEvent("DX_OpSc_04", gameObject, (uint)AkCallbackType.AK_EnableGetSourcePlayPosition | (uint)AkCallbackType.AK_EndOfEvent);
        subText.text = "Ready to initiate manual piloting controls on your command!";
        if (in_type04 == AkCallbackType.AK_EndOfEvent)
        {
            yield return new WaitForSecondsRealtime(initDelay);
            hasPlayed = hasPlayed + 1;
        }
    }
	*/
}