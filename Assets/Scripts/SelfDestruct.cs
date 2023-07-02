using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public float selfDestuctTime = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        selfDestuctTime -= Time.deltaTime;
        if (selfDestuctTime <=0)
        {
            Destroy (gameObject);
        }
		
	}
}
