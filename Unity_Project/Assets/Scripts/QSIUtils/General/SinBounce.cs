﻿using UnityEngine;
using System.Collections;

public class SinBounce : MonoBehaviour 
{
	public float timeScale = 0.3f;
	public float bounceFactor = 3;
	public bool xBounce = false;
	public bool yBounce = true;
	public bool zBounce = false;

	public Vector3 offset = new Vector3(0,3,0);

	public Transform anchor;
	private Vector3 bounce;
	private float bounceClock;
	private Vector3 originalPos;

	// Use this for initialization
	void Start () 
	{
		originalPos = transform.position;

		bounce = Vector3.zero;
		bounceClock = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{

		bounceClock += Time.deltaTime * timeScale;

		if(xBounce)
			bounce.x = Mathf.Sin (bounceClock)*bounceFactor;

		if(yBounce)
			bounce.y = Mathf.Sin (bounceClock)*bounceFactor;

		if(zBounce)
			bounce.z = Mathf.Sin (bounceClock)*bounceFactor;

		Vector3 baseLoc;

		if(anchor != null)
			baseLoc = anchor.position;
		else
			baseLoc = originalPos;

		transform.position = baseLoc + offset + bounce;
	
	}
}
