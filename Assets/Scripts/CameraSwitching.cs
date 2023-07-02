using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
    public Camera primaryCamera;
    public Camera secondaryCamera;

    // Use this for initialization
    void Start()
    {
        primaryCamera.enabled = true;
        secondaryCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            primaryCamera.enabled = !primaryCamera.enabled;
            secondaryCamera.enabled = !secondaryCamera.enabled;
        }
    }

    public void Reset()
    {
        primaryCamera.enabled = true;
        secondaryCamera.enabled = false;
    }
}