using UnityEngine;
using System.Collections;

public class SpellTotem : MonoBehaviour
{
    public Transform spawnLocation;
    public GameObject currentSpell;
    public SpellDetector mySpellDetector;
    public Renderer readyIndicator;

    public Color notReadyColour = Color.white;
    public Color readyColour = Color.green;
    public Material readyMaterial;
    public float timeCredit;

    private Material originalMaterial;

	// Use this for initialization
	void Start ()
    {
        if (mySpellDetector == null)
            mySpellDetector = FindObjectOfType<SpellDetector>();


        originalMaterial = readyIndicator.material;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (readyIndicator != null)
        {
            if (SpellDetector.Instance.GetActiveAltarCount() >= 5)
            {
                readyIndicator.material = readyMaterial;
                readyIndicator.material.color = readyColour;
                
            }
            else
            {
                readyIndicator.material = originalMaterial;
                readyIndicator.material.color = notReadyColour;
            }

        }
	}

    public void SpawnSpell()
    {
        Debug.Log("Spell Totem: " + SpellDetector.Instance.GetActiveAltarCount());

        //spawn the spell if they successfully put in a special recipe
        if(currentSpell != null)
        { 
            Instantiate(currentSpell, spawnLocation.position, spawnLocation.rotation);            
            currentSpell = null;
            mySpellDetector.discoveredSpell.discovered = true;
            SpellBook.Instance.UpdateSpellBook();
            SpellBook.Instance.GoToPage(mySpellDetector.discoveredSpellIndex + 1);
            
            
        }

        //clear the altars regardless of what recepie they put in...
        if(SpellDetector.Instance.GetActiveAltarCount() >= 5)
        { 
            LavaManager.Instance.AddTimeLeft(timeCredit);
            mySpellDetector.DestroyIngredients();
        }
    }

    public void UpdateSpell(GameObject newSpell)
    {
        currentSpell = newSpell;
    }
}
