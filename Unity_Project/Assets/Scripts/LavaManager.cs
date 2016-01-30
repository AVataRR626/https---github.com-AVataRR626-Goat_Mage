using UnityEngine;
using System.Collections;

public class LavaManager : Singleton<LavaManager>
{

    // guarantee this will be always a singleton only - can't use the constructor!
    protected LavaManager() { }

    [Range(10,300)]
    public float GameBaseDuration = 120;

    public float StartingLavaHeight = -10;
    public float EndGameLavaHeight = 10;
    
    public float TimeCompletion
    {
        get { return Mathf.Clamp(TimePassed, 0.0f, GameBaseDuration)/GameBaseDuration; }
    }

    public float TimePassed = 0.0f;

    // Use this for initialization
    void Start ()
    {
        Reset();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (UIManager.Instance.State == UIState.GameHud)
	    {
	        TimePassed += Time.deltaTime;
            gameObject.transform.position = new Vector3(0, Mathf.Lerp(StartingLavaHeight,EndGameLavaHeight, TimeCompletion), 0);
	    }
	    
    }

    public void AddTimeLeft(float t)
    {   
        TimePassed = Mathf.Clamp(TimePassed -t, 0, GameBaseDuration);
    }

    public void Reset()
    {
        TimePassed = 0.0f;
        gameObject.transform.position = new Vector3(0,StartingLavaHeight,0);
    }
}
