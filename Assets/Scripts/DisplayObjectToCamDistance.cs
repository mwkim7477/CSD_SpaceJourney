using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayObjectToCamDistance : MonoBehaviour {

    public GameObject thisObject;

    public Vector3 offset;

	// Use this for initialization
	void Start () {

        offset = transform.position - thisObject.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

        offset = transform.position - thisObject.transform.position;

    }
}
