using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIAltarOrbUpdate : MonoBehaviour
{

    [Range(0, 4)] public int AltarNumber;
    public bool status;

    private Image orbImage;

    void Start()
    {
        orbImage = gameObject.GetComponent<Image>();
    }

	// Update is called once per frame
	void Update ()
	{
        //TODO
        //status = true; // REPLACE WITH SpellDetector.Instance.GetAlterStatus(AlterNumber);

        status = SpellDetector.Instance.GetAltarStatus(AltarNumber);

	    orbImage.enabled = status;
	}
}
