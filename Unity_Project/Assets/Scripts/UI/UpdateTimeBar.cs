﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateTimeBar : MonoBehaviour
{

    public Text Text;
    public Slider Slider;
    public string DisplayText = "Time Left: ";
    public float TimeMax;
    public float TimeValue;

	// Update is called once per frame
	void Update ()
	{
        TimeMax = LavaManager.Instance.GameBaseDuration;
	    TimeValue = TimeMax - (TimeMax*LavaManager.Instance.TimeCompletion);

        //set values to their objects.
	    Text.text = DisplayText + TimeValue.ToString("F2");
	    Slider.maxValue = TimeMax;
	    Slider.minValue = 0;
	    Slider.value = TimeValue;
	}
}
