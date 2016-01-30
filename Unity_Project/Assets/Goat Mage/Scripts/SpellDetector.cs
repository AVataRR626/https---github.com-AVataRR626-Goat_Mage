using UnityEngine;
using System.Collections;


public class SpellDetector : Singleton<SpellDetector>
{

    public Pedestal[] myAltars;
    public int[] ingredientTally;

    //guarantee this will be always a singleton only - can't use the constructor!
    protected SpellDetector()
    {
        
    }

    void Start()
    {
        myAltars = FindObjectsOfType<Pedestal>();
    }

    void Update()
    {
        TallyIngredients();
    }

    void TallyIngredients()
    {
        ingredientTally = new int[4];

        for (int i = 0; i < ingredientTally.Length;)
            ingredientTally[i] = 0;

        foreach (Pedestal a in myAltars)
        {
            if(a.myItem != null)
            {
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
                    ingredientTally[1]++;
                }

                if (a.myItem.type == "Skull")
                {
                    ingredientTally[0]++;
                }
            }
        }
    }

    public bool GetAltarStatus(int i)
    {
        return myAltars[i].myItem != null;
    }

}
