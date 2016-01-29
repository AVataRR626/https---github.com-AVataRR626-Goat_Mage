using UnityEngine;
using System.Collections;

/*BounceBlaster Project
CameraClickMove.cs

Matt's basic way of click-panning.

Authors:
1) Matt Cabanag
2) ..
3) ..

*/

public class CameraClickMove : MonoBehaviour 
{
	//public LayerMask qBrickMask = 8;
	public bool pauseMove = false;
	public float moveFactor = 1.25f;
	public float leftBorder = -3;
	public float rightBorder = 3;
	public float topBorder = -3;
	public float bottomBorder =3;
	public KeyCode moveKey = KeyCode.Mouse0;
	public KeyCode cancelMoveKey = KeyCode.Mouse1;
	public float maxForceMoveDelta = 0.5f;

	
	private bool moveMode = false;
	private bool paralaxMove = false;
	private Vector3 mouseDown = Vector3.zero;
	private Vector3 currentMousePos = Vector3.zero;
	private Vector3 mouseScreenPos;
	private Vector3 prevMouse;
	//private Paralaxer [] paralaxList;
	
	// Use this for initialization
	void Start () 
	{
		//list all the paralaxable items;
		//paralaxList = FindObjectsOfType(typeof(Paralaxer)) as Paralaxer [];
	}
	
	// Update is called once per frame
	void Update () 
	{
		//don't let this interfere with zooming
		//if(Input.touchCount <= 1)
		{
			mouseScreenPos = Input.mousePosition;
			currentMousePos = Input.mousePosition;

			if(Input.GetKeyDown(moveKey))
			{
				mouseDown = Input.mousePosition;

			}


			if(Input.GetKey(moveKey) && !Input.GetKey (cancelMoveKey))
			{
				moveMode = !pauseMove;
				paralaxMove = moveMode;
				currentMousePos = Input.mousePosition;

				Vector3 delta = (prevMouse - currentMousePos);
				delta.z = delta.y;
				delta.y = 0;

				MoveCam(delta);
				

			}

			//disable movement after every button release
			if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetKeyUp(moveKey))
			{
				moveMode = false;
			}

			prevMouse = currentMousePos;
		}
	}

	void MoveCam(Vector3 delta)
	{
		if(moveMode)
		{
			transform.position += delta*moveFactor*Time.deltaTime;
		}
		
		if(paralaxMove)
		{
			if(transform.position.x <= leftBorder || transform.position.x >= rightBorder)				
				delta.x = 0;
			
			if(transform.position.z <= topBorder || transform.position.z >= bottomBorder)
				delta.z = 0;

			/*
			foreach(Paralaxer p in paralaxList)
			{
				p.transform.position += delta*-p.moveFactor;
			}
			*/
		}
	}

	public void ForceMoveCam(Vector3 delta)
	{
		moveMode = true;

		if(delta.magnitude > maxForceMoveDelta)
		{
			delta.Normalize();
			delta *= maxForceMoveDelta;
		}

		MoveCam(delta);
	}
}
