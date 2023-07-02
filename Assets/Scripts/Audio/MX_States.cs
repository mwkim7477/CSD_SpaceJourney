using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MX_States : MonoBehaviour {

    bool combatIdleSet;

    public static int enEngaged = 0;

    SpawnManager spawnManager;

	// Use this for initialization
	void Start ()
    {
        SetExplore();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (ScoreManager.score < 50)
        {
            return;
        }

        if (ScoreManager.score == 50)
        {
            SetCombatIdle();
        }

        if (enEngaged == 0)
        {
            SetCombatLvl00();
            SetCombatIdle();
        }

        if (enEngaged > 0)
        {
            SetCombatEngaged();
        }

        
       
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyEngagement")
        {
            Debug.Log("TrigDetect");
            
            enEngaged = enEngaged + 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "EnemyEngagement")
        {
            Debug.Log("TrigDetect");
            
            enEngaged = enEngaged - 1;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "EnemyEngagement" && enEngaged == 1)
        {
            SetCombatLvl01();
        }

        if (other.gameObject.tag == "EnemyEngagement" && enEngaged == 2)
        {
            SetCombatLvl02();
        }

        if (other.gameObject.tag == "EnemyEngagement" && enEngaged == 3)
        {
            SetCombatLvl03();
        }

        
        

    }

    void SetExplore()
    {
//********        AkSoundEngine.PostEvent("MX_Explore", gameObject);
    }

    void SetCombatIdle()
    {
//********        AkSoundEngine.PostEvent("MX_CombatIdle", gameObject);
    }

    void SetCombatEngaged()
    {
//********        AkSoundEngine.PostEvent("MX_CombatEngaged", gameObject);
    }

    void SetCombatLvl00()
    {
//********        AkSoundEngine.PostEvent("MX_Combat_00", gameObject);
    }

    void SetCombatLvl01()
    {
//********        AkSoundEngine.PostEvent("MX_Combat_01", gameObject);
    }

    void SetCombatLvl02()
    {
//********        AkSoundEngine.PostEvent("MX_Combat_02", gameObject);
    }

    void SetCombatLvl03()
    {
//********        AkSoundEngine.PostEvent("MX_Combat_03", gameObject);
    }
}
