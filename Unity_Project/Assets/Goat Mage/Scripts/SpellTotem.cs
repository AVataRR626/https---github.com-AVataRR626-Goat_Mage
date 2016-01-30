using UnityEngine;
using System.Collections;

public class SpellTotem : MonoBehaviour
{
    public Transform spawnLocation;
    public GameObject currentSpell;

	// Use this for initialization
	void Start ()
    {
	
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
        }
    }

    public void UpdateSpell(GameObject newSpell)
    {
        currentSpell = newSpell;
    }
}
