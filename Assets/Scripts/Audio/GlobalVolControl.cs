using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVolControl : MonoBehaviour {

    public static GlobalVolControl instance;

    public float masterVol;
    public float sfxVol;
    public float musicVol;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        masterVol = 100f;
        sfxVol = 100f;
        musicVol = 100f;
    }
}
