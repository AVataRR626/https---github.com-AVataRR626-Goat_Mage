using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateHealthbar : MonoBehaviour
{

    public QSIKillable HealthScript;

    public Slider Slider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{

	    Slider.minValue = 0.0f;
	    Slider.maxValue = HealthScript.maxHealth;
	    Slider.value = HealthScript.health;
	}
}
