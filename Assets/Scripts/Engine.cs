using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engine : MonoBehaviour {

    public SpaceshipController spaceshipController;

    public Text enginePowerText;
    public Slider enginePowerSlider;
    public float currentSpeed;
    public int enginePowerInt;
    public float enginePowerFloat;



    private void Awake()
    {
        currentSpeed = spaceshipController.CurrentSpeed;
        enginePowerInt = Mathf.RoundToInt(spaceshipController.CurrentSpeed) / 10;
        enginePowerFloat = spaceshipController.CurrentSpeed / 10;

        enginePowerText.text = "Engine Power: 25%";
        enginePowerSlider.value = 25;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        EnginePower();
	}

    void EnginePower()
    {
        enginePowerFloat = spaceshipController.CurrentSpeed / 10;

        enginePowerInt = Mathf.RoundToInt(spaceshipController.CurrentSpeed) / 10;

        enginePowerText.text = "Engine Power: " + enginePowerInt.ToString() + "%";

        enginePowerSlider.value = enginePowerInt;
    }
}
