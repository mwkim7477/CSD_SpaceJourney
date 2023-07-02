using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TriggerOverlap : MonoBehaviour
{
    public StudioEventEmitter asteroidAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        asteroidAudio.Play();
        Debug.Log(other.tag);
    }

    void OnTriggerExit(Collider other)
    {
    
    }
}

