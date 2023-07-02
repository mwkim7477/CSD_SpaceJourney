using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour {

    public static GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Ship_1");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
