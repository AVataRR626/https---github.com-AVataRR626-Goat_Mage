using UnityEngine;
using System.Collections;


public class SpellDetector : Singleton<SpellDetector>
{

    public Pedestal[] myAltars;
    public int[] ingredientTally;
    public Transform spellSpawnPoint;
    public SpellTotem myTotem;

    //guarantee this will be always a singleton only - can't use the constructor!
    protected SpellDetector()
    {
        
    }

    void Start()
    {
        if(myAltars == null)
            myAltars = FindObjectsOfType<Pedestal>();

        ingredientTally = new int[4];

        if (myTotem == null)
            myTotem = FindObjectOfType<SpellTotem>();
    }

    void Update()
    {
        if(IngredientCount() == 5)
            DetectSpells();
    }


    void TallyIngredients()
    {   

        for (int i = 0; i < ingredientTally.Length; i++)
            ingredientTally[i] = 0;

        foreach (Pedestal a in myAltars)
        {
            if(a.myItem != null)
            {
                Debug.Log(name + " myItem: " + a.myItem.type);

                if(a.myItem.type == "Book")
                {
                    ingredientTally[0]++;
                }

                if (a.myItem.type == "Candle")
                {
                    ingredientTally[1]++;
                }

                if (a.myItem.type == "Eyeball")
                {
                    ingredientTally[2]++;
                }

                if (a.myItem.type == "Skull")
                {
                    ingredientTally[3]++;
                }
            }
        }
    }

    /*
    public Recepie GetRecepie(int i)
    {
        Recepie result;



        //return result;
    }*/

    void DetectSpells()
    {
        Debug.Log("Detect Ingredients...");

        TallyIngredients();

        foreach (Transform t in transform)
        {
            Recepie r = t.GetComponent<Recepie>();

            if (r != null)
            {
                bool success = true;

                for (int i = 0; i < 4; i++)
                {
                    if (r.ingredients[i] != ingredientTally[i])
                        success = false;
                }

                if(success)
                {
                    if (myTotem != null)
                        myTotem.currentSpell = r.spell;

                    DestroyIngredients();
                }
            }
        }

        DestroyIngredients();

    }

    [ContextMenu("ClearStuff")]
    public void DestroyIngredients()
    {
        for(int i = 0; i < myAltars.Length; i++)
        {
            if (myAltars[i].myItem != null)
            { 
                Destroy(myAltars[i].myItem.gameObject);
                myAltars[i].myItem = null;
            }
        }
    }

    public int IngredientCount()
    {
        int tally = 0;

        for (int i = 0; i < myAltars.Length; i++)
        {
            if (myAltars[i].myItem != null)
            {
                tally++;
            }
        }

        return tally;
    }

    public bool GetAltarStatus(int i)
    {
        return myAltars[i].myItem != null;
    }

}
