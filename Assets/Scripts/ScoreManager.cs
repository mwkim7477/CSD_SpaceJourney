﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;

    Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<Text>();
        score = 0;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        scoreText.text = "Scrore: " + score;

	}
}
