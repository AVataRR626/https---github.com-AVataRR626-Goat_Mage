using UnityEngine;
using System.Collections;

public class SpellTotem : MonoBehaviour
{
    public Transform spawnLocation;
    public GameObject currentSpell;
    public SpellDetector mySpellDetector;

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
        if(currentSpell != null)
        { 
            Instantiate(currentSpell, spawnLocation.position, spawnLocation.rotation);            
            currentSpell = null;
            mySpellDetector.discoveredSpell.discovered = true;
            SpellBook.Instance.UpdateSpellBook();
        }

        mySpellDetector.DestroyIngredients();
    }

    public void UpdateSpell(GameObject newSpell)
    {
        currentSpell = newSpell;
    }
}
