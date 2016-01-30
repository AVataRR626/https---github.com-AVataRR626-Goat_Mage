using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using InControl;

public class SpellBook : Singleton<SpellBook>
{
    // guarantee this will be always a singleton only - can't use the constructor!
    protected SpellBook() { }

    public int CurrentPage;
    public int Pages;

    public bool CurrentPageDiscovered;
    public Text PageNumberText;
    public Text SpellName;
    public Text BooksNeeded;
    public Text CandlesNeeded;
    public Text EyesNeeded;
    public Text SkullsNeeded;


	// Use this for initialization
	void Start ()
	{
        //TODO
	    CurrentPage = 1;        
        Pages = SpellDetector.Instance.GetRecipeCount();

        

    }

    private void UpdateTexts()
    {
        PageNumberText.text = "Page: " + CurrentPage;
        //CurrentPageDiscovered = true; 

        //the recepie!
        Recipe r = SpellDetector.Instance.GetRecipe(CurrentPage - 1);

        CurrentPageDiscovered = r.discovered;

        if (CurrentPageDiscovered == true)
        {
            SpellName.text = r.spellName; //SpellDetector.GetRecipe(CurrentPage - 1).spellName;
            BooksNeeded.text = "" + r.ingredients[0]; //SpellDetector.GetRecipe(CurrentPage - 1).ingredients[0];
            CandlesNeeded.text = "" + r.ingredients[1]; //SpellDetector.GetRecipe(CurrentPage - 1).ingredients[1];
            EyesNeeded.text = "" + r.ingredients[2]; //SpellDetector.GetRecipe(CurrentPage - 1).ingredients[2];
            SkullsNeeded.text = "" + r.ingredients[3]; //SpellDetector.GetRecipe(CurrentPage - 1).ingredients[3];
        }
        else
        {
            SpellName.text = "Undiscovered";
            BooksNeeded.text = "?";
            CandlesNeeded.text = "?";
            EyesNeeded.text = "?";
            SkullsNeeded.text = "?";
        }
        
    }

    [ContextMenu("Previous Page")]
    public void PreviousPage()
    {

        if (CurrentPage > 1)
            CurrentPage--;
        else
            CurrentPage = Pages;

        UpdateTexts();
    }

    [ContextMenu("Next Page")]
    public void NextPage()
    {
        if (CurrentPage < Pages)
            CurrentPage++;
        else
            CurrentPage = 1;

        UpdateTexts();
    }

    [ContextMenu("UpdateSpellbook")]
    public void UpdateSpellBook()
    {
        UpdateTexts();
    }
}
