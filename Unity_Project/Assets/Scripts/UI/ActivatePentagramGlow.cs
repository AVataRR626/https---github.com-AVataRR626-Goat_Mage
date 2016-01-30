using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActivatePentagramGlow : MonoBehaviour
{

    public UIAltarOrbUpdate[] Orbs;
    public Color32 ActiveColor;
    public Color32 InactiveColor;
    public Outline Target;
    public bool status = false;
    
	// Update is called once per frame
	void Update ()
	{
	    status = true;
	    foreach (var orbupdater in Orbs)
	    {
	        if (orbupdater.status == false)
	        {
	            status = false;
	        }
	    }

	    Target.effectColor = status ? ActiveColor : InactiveColor;

	}
}
