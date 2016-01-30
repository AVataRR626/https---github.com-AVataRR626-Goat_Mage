using UnityEngine;
using System.Collections;

public class SpellTotem : MonoBehaviour
{
    public Transform spawnLocation;
    public GameObject currentSpell;
    public SpellDetector mySpellDetector;
    public float timeCredit;

	// Use this for initialization
	void Start ()
    {
        if (mySpellDetector == null)
            mySpellDetector = FindObjectOfType<SpellDetector>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void SpawnSpell()
    {
        Debug.Log("Spell Totem: " + SpellDetector.Instance.GetActiveAltarCount());

        if(currentSpell != null)
        { 
            Instantiate(currentSpell, spawnLocation.position, spawnLocation.rotation);            
            currentSpell = null;
            mySpellDetector.discoveredSpell.discovered = true;
            SpellBook.Instance.UpdateSpellBook();
            
        }

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
